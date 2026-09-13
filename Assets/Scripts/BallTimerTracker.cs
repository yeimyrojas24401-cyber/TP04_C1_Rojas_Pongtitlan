using UnityEngine;

public class BallTimerTracker : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] private GameSettingsSo settingsData;
    [SerializeField] private ScoreDataSo scoreData;
    [SerializeField] private Ball ball;

    private float timer;
    private bool isOnLeftSide;


    private void Start()
    {
        if (transform.position.x < settingsData.centerX)
        {
            isOnLeftSide = true;
        }
        else
        {
            isOnLeftSide = false;
        }
        timer = 0f;
    }
    private void Update()
    {
        bool currentlyOnLeft = transform.position.x < settingsData.centerX;

        if (currentlyOnLeft != isOnLeftSide)
        {
            isOnLeftSide = currentlyOnLeft;
            timer = 0f;
            return;
        }
        timer += Time.deltaTime;
        if (timer >= settingsData.time)
        {
            if (isOnLeftSide)
                scoreData.AddRightPoint();
            else
                scoreData.AddLeftPoint();

            ball.ResetBall();
            timer = 0f;
        }
    }
}