using UnityEngine;

public class BallTimer : MonoBehaviour
{
    [SerializeField] private float timer = 20f;

    private bool timerActive = false;

    private void Update()
    {
        if (timerActive)
        {
            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                timer = 0;

                MakeGoal();
            }
        }
    }

    public void StartTimer()
    {
        timer = 20f;
        timerActive = true;
    }

    public void StopTimer()
    {
        timerActive = false;
        timer = 20f;
    }

    private void MakeGoal()
    {
        timerActive = false;

        if (transform.position.x < 0)
        {
            Debug.Log("¡Gol para el jugador derecho!");
        }
        else
        {
            Debug.Log("¡Gol para el jugador izquierdo!");
        }
    }
}