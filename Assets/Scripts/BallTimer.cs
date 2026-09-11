using UnityEngine;

public class BallTimer : MonoBehaviour
{
    [SerializeField] private float timer = 3f;

    private bool timerActive = false;

    private void Update()
    {
        if (timerActive)
        {
            timer -= Time.deltaTime;

            Debug.Log(timer);

            if (timer <= 0)
            {
                timer = 0;
                timerActive = false;

                Debug.Log("¡Se acabó el tiempo!");
            }
        }
    }
}