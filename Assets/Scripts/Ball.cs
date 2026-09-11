using UnityEngine;

public class Ball : MonoBehaviour
{

    [SerializeField] private float initialVelocity = 0.1f; // variable modificable en el editor
    [SerializeField] private float velocityMultiplier = 1.1f;
    private Rigidbody2D ballRb; // aqui es una variable para mandar a llamar al rigid body que hay dentro de esto
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        ballRb = GetComponent<Rigidbody2D>(); // apenas inicia traeme al componente
        Launch(); // ejecuta launch apenas despierta
    }
    private void Launch()
    {
        float xVelocity = Random.Range(0, 2) == 0 ? 1 : -1; // PREGUNTAR SOBRE ESTA LINEA // PREGUNTAR POR QUE NO VA EN EL UPDATE
        float yVelocity = Random.Range(0, 2) == 0 ? 1 : -1;
        ballRb.linearVelocity = new Vector2(xVelocity, yVelocity) * initialVelocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Paddle"))
        {
            ballRb.linearVelocity *= velocityMultiplier;
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
