using UnityEngine;

public class GoalZone : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] private ScoreDataSo scoreData;
    [SerializeField] private Ball ball;

    [Header("Settings")]
    [SerializeField] private bool isLeftGoal;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.TryGetComponent<BallMarker>(out _)) return;

        if (isLeftGoal)
            scoreData.AddRightPoint();
        else
            scoreData.AddLeftPoint();

        ball.ResetBall();
    }
}
