using System;
using UnityEngine;
[CreateAssetMenu(fileName = "GameSettings", menuName = "Data/Game/GameSettings")]
public class GameSettingsSo : ScriptableObject
{
    [Header("RoundSettings")]

    // Warning: los arrays de opciones y centerX son public, así que cualquier script puede reordenarlos o pisarlos. Los índices sí los protegiste bien con [NonSerialized] y con los métodos Set.
    // Pasá los tres a [SerializeField] private y exponé los arrays con una property de solo lectura, como ya hacés con rounds y time. Lo mismo en PlayerDataSo.cs:7.
    public int[] roundsToWinOptions = {2,3,4};
    [NonSerialized] public int roundsToWinIndex = 1;

    [Header("Time Settings")]

    // Warning: los tres .asset todavía guardan claves de versiones anteriores de estas clases. GameSettings.asset tiene roundsToWin: 4 y maxTimeOnSide: 5, PlayerDataP1.asset tiene color: {r: 0, g: 1, b: 0} y PlayerDataP2.asset tiene speed: 3. Ninguna de esas cuatro claves existe hoy en el código.
    // Como los arrays tampoco están guardados, los valores que usa el juego salen de los inicializadores de estos campos, no del asset. Abrí los tres en el inspector, tocalos y guardalos para que queden limpios.
    public float[] maxTimeOnSideOptions = { 5f, 10f, 20f};
    // Suggestion: maxTimeOnSideIndex arranca en 1, que en el array {5, 10, 20} es 10 segundos. La consigna pide un límite de 20 segundos.
    // El sistema está bien y el valor se elige desde el menú; lo que conviene cambiar es el índice por defecto a 2.
    [NonSerialized] public int maxTimeOnSideIndex = 1;

    [Header("Side")]
    public float centerX = 0f;

    //Events
    public event Action<int> OnRoundsToWinChanged;
    public event Action<float> OnTimeOnSideChanged;

    //Properties

    public int rounds
    {
        get
        {
            if (roundsToWinOptions != null && roundsToWinOptions.Length > 0)
            {
                return roundsToWinOptions[Mathf.Clamp(roundsToWinIndex, 0, roundsToWinOptions.Length - 1)];
            }
            else
            {
                return 0;
            }
        }
    }
    public float time
    {
        get
        {
            if (maxTimeOnSideOptions != null && maxTimeOnSideOptions.Length > 0)
            {
                return maxTimeOnSideOptions[Mathf.Clamp(maxTimeOnSideIndex, 0, maxTimeOnSideOptions.Length - 1)];
            }
            else
            {
                return 0;
            }
        }
    }
    public void SetRoundsToWinIndex (int index)
    {
        if (roundsToWinOptions == null || roundsToWinOptions.Length == 0) return;
        roundsToWinIndex = Mathf.Clamp(index, 0, roundsToWinOptions.Length - 1);
        OnRoundsToWinChanged?.Invoke(rounds);
    }

    public void SetMaxTimeOnSideIndex (int index)
    {
        if (maxTimeOnSideOptions == null || maxTimeOnSideOptions.Length == 0) return;
        maxTimeOnSideIndex = Mathf.Clamp(index, 0, maxTimeOnSideOptions.Length - 1);
        OnTimeOnSideChanged?.Invoke(time);
    }

}
