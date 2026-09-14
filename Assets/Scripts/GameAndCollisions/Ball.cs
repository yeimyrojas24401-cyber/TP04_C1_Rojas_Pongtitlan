using UnityEngine;

public class Ball : MonoBehaviour
{

    [SerializeField] private float initialVelocity = 10f; // variable modificable en el editor
    [SerializeField] private float velocityMultiplier = 1.1f;

    [SerializeField] private float maxSpeed = 15f;
    [SerializeField] private float maxLaunchAngle = 30f;
    private Rigidbody2D ballRb; // aqui es una variable para mandar a llamar al rigid body que hay dentro de esto
    private Vector3 startPosition;
    void Awake()
    {
        ballRb = GetComponent<Rigidbody2D>(); // apenas inicia traeme al componente
        startPosition = transform.position;
        Launch(); // ejecuta launch apenas despierta
    }
    private void Launch()
    {
        //Base direction: esto mueve de mandera random a la izq, der, arriba o abajo
        float xDir = Random.Range(0, 2) == 0 ? 1 : -1;
        float yDir = Random.Range(0, 2) == 0 ? 1 : -1;

        // ahora lo siguiente a resolver es que tener un angulo random para que se lauchee
        float angleOffset = Random.Range(-maxLaunchAngle, maxLaunchAngle);
        Vector2 baseDir = new Vector2(xDir, yDir).normalized;
        Vector2 launchDir = Quaternion.Euler(0, 0, angleOffset) * baseDir;

        ballRb.linearVelocity = launchDir * initialVelocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<PaddleMarker>(out _))
        {
            Vector2 newVelocity = ballRb.linearVelocity * velocityMultiplier;

            if (newVelocity.magnitude > maxSpeed)
            {
                newVelocity = newVelocity.normalized * maxSpeed;
            }

            ballRb.linearVelocity = newVelocity;
        }
    }
    public void ResetBall()
    {
        transform.position = startPosition;
        Launch();
    }
}
