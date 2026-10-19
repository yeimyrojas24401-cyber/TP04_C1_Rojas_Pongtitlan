using UnityEngine;

public class Movement : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] private PlayerDataSo data;

    [SerializeField] private bool isContinuousMovement = true;

    // Suggestion: moveSpeedPlayer está marcado como Debug y serializado, pero lo pisa el OnEnable con data.speed y después cada evento OnSpeedChanged. Lo que se escriba en el inspector no dura ni un frame.
    // Si es solo para mirar, dejalo private y agregale un atributo de solo lectura, o sacale el [SerializeField].
    [Header("Debug: ")]
    [SerializeField] private float moveSpeedPlayer = 1000.0f;

    [Header("Field Limits")]
    [SerializeField] private float minX = -8f;
    [SerializeField] private float center = 0f;
    [SerializeField] private float maxX = 8f;
    [SerializeField] private bool isLeftSide = true;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        data.OnSpeedChanged += HandleSpeedChanged;
        moveSpeedPlayer = data.speed; // sincroniza apenas se activa/reactiva
    }

    private void OnDisable()
    {
        data.OnSpeedChanged -= HandleSpeedChanged;
    }

    private void HandleSpeedChanged(float newSpeed)
    {
        moveSpeedPlayer = newSpeed;
    }


    private void FixedUpdate()
    {
        if (isContinuousMovement)
        // Warning: AddForce ya integra el tiempo por dentro, no hay que multiplicar por Time.fixedDeltaTime. Como fixedDeltaTime vale 0.02, la fuerza queda dividida por cincuenta, y por eso las opciones de velocidad del SO son 500, 1000 y 2000.
        // Sacá el Time.fixedDeltaTime de las cuatro llamadas y bajá speedOptions a números que se puedan leer. Es el mismo punto que te marqué en el TP03.
        {
            if (Input.GetKey(data.moveUp))
                rb.AddForce(new Vector2(0, moveSpeedPlayer * Time.fixedDeltaTime));
            if (Input.GetKey(data.moveRight))
                rb.AddForce(new Vector2(moveSpeedPlayer * Time.fixedDeltaTime, 0));
            if (Input.GetKey(data.moveDown))
                rb.AddForce(new Vector2(0, -moveSpeedPlayer * Time.fixedDeltaTime));
            if (Input.GetKey(data.moveLeft))
                rb.AddForce(new Vector2(-moveSpeedPlayer * Time.fixedDeltaTime, 0));
        }

        ClampPosition();
    }

    private void ClampPosition()
    {
        Vector2 clampedPos = rb.position;
        Vector2 velocity = rb.linearVelocity;

        float clampedX;

        if (isLeftSide)
            clampedX = Mathf.Clamp(clampedPos.x, minX, center);
        else
            clampedX = Mathf.Clamp(clampedPos.x, center, maxX);

        if (!Mathf.Approximately(clampedX, clampedPos.x))
            velocity.x = 0f;

        clampedPos.x = clampedX;

        rb.position = clampedPos;
        // Warning: rb.position y rb.linearVelocity se reescriben en cada FixedUpdate, esté el jugador contra el límite o no. Escribir rb.position teletransporta el cuerpo y saltea la detección de colisiones.
        // Aplicá el clamp solo cuando hizo falta (ya calculás ese caso con Mathf.Approximately) y usá rb.MovePosition.
        rb.linearVelocity = velocity;
    }
}