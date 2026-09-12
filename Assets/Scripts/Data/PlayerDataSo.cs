using System;
using UnityEngine;
[CreateAssetMenu(fileName = "PlayerData", menuName = "Data/Game/PlayerData")]
public class PlayerDataSo : ScriptableObject
{
    [Header("MovementSettings")]
    public KeyCode moveUp = KeyCode.W;
    public KeyCode moveDown = KeyCode.S;
    public KeyCode moveRight = KeyCode.D;
    public KeyCode moveLeft = KeyCode.A;

    [Header("SpeedSettings")]
    public float[] speedOptions = { 500f, 1000f, 2000f };
    [NonSerialized] public int speedIndex = 1; //asi lo ponemos en default en la posicion 1 = 1000
    public float speed => (speedOptions != null && speedOptions.Length >0)
        ? speedOptions[Mathf.Clamp(speedIndex, 0, speedOptions.Length -1)] : 0f;
    public event Action<float> OnSpeedChanged;
    public void SetSpeedIndex (int index)
    {
        if (speedOptions == null || speedOptions.Length == 0) return;
        speedIndex = Mathf.Clamp(index, 0, speedOptions.Length - 1);
        OnSpeedChanged?.Invoke(speed);
    }

    [Header("VisualSettings")]
    public GameObject [] variantPrefabs = new GameObject[3]; // aqui hice un array de 3 para la informacion de sus sprites
    public Color color = Color.white;

    [NonSerialized] public int variantIndex = 0;

    public GameObject CurrentVariant => (variantPrefabs != null && variantPrefabs.Length > 0)
        ? variantPrefabs[Mathf.Clamp(variantIndex, 0, variantPrefabs.Length - 1)]
        : null;

    public event Action<int> OnVariantChanged;
    public event Action<Color> OnColorChanged;
    public void SetVariantIndex(int index)
    {
        if (variantPrefabs == null || variantPrefabs.Length == 0) return;
        variantIndex = Mathf.Clamp(index, 0, variantPrefabs.Length - 1);
        OnVariantChanged?.Invoke(variantIndex);
    }
    public void SetColor(Color newColor)
    {
        color = newColor;
        OnColorChanged?.Invoke(color);
    }

}
