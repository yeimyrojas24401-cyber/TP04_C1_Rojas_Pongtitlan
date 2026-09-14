using UnityEngine;
using TMPro;

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