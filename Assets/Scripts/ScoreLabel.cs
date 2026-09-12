using UnityEngine;
using TMPro;

public class ScoreLabel : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] private ScoreDataSo scoreData;
    [SerializeField] private TextMeshPro leftLabel;
    [SerializeField] private TextMeshPro rightLabel;

    private void OnEnable()
    {
        HandleLeftChanged(scoreData.leftScore);
        HandleLeftChanged(scoreData.rightScore);
        scoreData.OnLeftScoreChanged += HandleLeftChanged;
        scoreData.OnRightScoreChanged += HandleRightChanged;
    }
    private void OnDisable()
    {
        scoreData.OnLeftScoreChanged -= HandleLeftChanged;
        scoreData.OnRightScoreChanged -= HandleRightChanged;
    }
    private void HandleLeftChanged(int score) => leftLabel.text = score.ToString();
    private void HandleRightChanged(int score) => rightLabel.text = score.ToString();
}
