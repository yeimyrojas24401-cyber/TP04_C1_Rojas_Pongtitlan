using UnityEngine;
using TMPro;

// Error: el archivo se llama RoundsToWinLabel.cs y la clase LabelRoundsToWin. Unity busca dentro de cada .cs una clase con el mismo nombre que el archivo; cuando no la encuentra, el componente no se puede agregar y los que ya están puestos pueden aparecer como Missing Script.
// Es el único archivo del proyecto con este problema: los otros veintiséis están bien. Renombralo desde el Project de Unity.
public class LabelRoundsToWin : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] private GameSettingsSo data;
    [SerializeField] private TMP_Text label;

    private void Awake()
    {
        data.OnRoundsToWinChanged += HandleRoundsChanged;
    }

    private void Start()
    {
        HandleRoundsChanged(data.rounds);
    }

    private void OnDestroy()
    {
        data.OnRoundsToWinChanged -= HandleRoundsChanged;
    }

    private void HandleRoundsChanged(int newRounds)
    {
        int bestOf = (newRounds * 2) - 1;
        label.text = $"Best of {bestOf}";
    }
}