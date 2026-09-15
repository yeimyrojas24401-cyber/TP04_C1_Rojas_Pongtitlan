using UnityEngine;

public class Movement : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] private PlayerDataSo data;

    [SerializeField] private bool isContinuousMovement = true;

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
        rb.linearVelocity = velocity;
    }
}