using UnityEngine;
using TMPro;
public class ColorLabel : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] private PlayerDataSo data;
    [SerializeField] private TMP_Text label;

    private void Awake()
    {
        data.OnColorChanged += HandleColorChanged;
    }
    private void Start()
    {
        HandleColorChanged(data.color);
    }
    private void HandleColorChanged(Color newColor)
    {
        label.text = GetColorName(newColor);
    }
    private string GetColorName(Color c)
    {
        if (c == Color.green) return "GREEN";
        if (c == Color.blue) return "BLUE";
        return "None";
    }
}
