using UnityEngine;
using TMPro;
public class ColorLabel : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] private PlayerDataSo data;
    [SerializeField] private TMP_Text label;

    private void OnEnable()
    {
        HandleColorChanged(data.color);
        data.OnColorChanged += HandleColorChanged;
    }
    private void OnDisable()
    {
        data.OnColorChanged -= HandleColorChanged;
    }
    private void HandleColorChanged(Color newColor)
    {
        label.text = GetColorName(newColor);
    }
    private string GetColorName(Color c)
    {
        if (c == Color.white) return "WHITE";
        if (c == Color.green) return "GREEN";
        if (c == Color.blue) return "BLUE";
        return "NONE";
    }
}
