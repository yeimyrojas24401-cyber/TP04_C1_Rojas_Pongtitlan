using UnityEngine;
using TMPro;

public class SpeedLabel : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] private PlayerDataSo data;
    [SerializeField] private TMP_Text label;

    private void OnEnable()
    {
        HandleSpeedChanged(data.speed);
        data.OnSpeedChanged += HandleSpeedChanged;
    }
    private void OnDisable()
    {
        data.OnSpeedChanged -= HandleSpeedChanged;
    }

    private void HandleSpeedChanged(float newSpeed)
    {
        label.text = $"{newSpeed:0}";
    }
}
