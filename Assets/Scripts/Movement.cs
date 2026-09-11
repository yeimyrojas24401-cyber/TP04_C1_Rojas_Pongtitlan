using UnityEngine;

public class Movement : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] private PlayerDataSo data;

    [SerializeField] private bool isContinuousMovement = true;

    private float moveSpeedPlayer;

    private Rigidbody2D rb;
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

    }
    private void Start ()
    {
        moveSpeedPlayer = data.speed;
    }

    private void FixedUpdate()
    {
       if (isContinuousMovement)
        {
            if (Input.GetKey(data.moveUp))
            {
                rb.linearVelocity = new Vector2(0, data.speed);
            }
            if (Input.GetKey(data.moveDown))
            {
                rb.linearVelocity = new Vector2(0, -data.speed);
            }
            if (Input.GetKey(data.moveRight))
            {
                rb.linearVelocity = new Vector2(data.speed, 0);
            }
            if (Input.GetKey(data.moveLeft))
            {
                rb.linearVelocity = new Vector2(-data.speed, 0);
            }
        }
    }
}
