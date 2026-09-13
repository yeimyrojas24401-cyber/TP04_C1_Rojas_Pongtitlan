using UnityEngine;
using TMPro;

public class MaxTimeLabel : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] private GameSettingsSo data;
    [SerializeField] private TMP_Text label;
    private void Awake()
    {
        data.OnTimeOnSideChanged += HandleTimeChanged;
    }
    private void Start()
    {
        HandleTimeChanged(data.time);
    }
    private void OnDestroy()
    {
        data.OnTimeOnSideChanged -= HandleTimeChanged;
    }
    private void HandleTimeChanged(float time)
    {
        label.text = $"Max time on side: {time:F0}s";
    }
}
