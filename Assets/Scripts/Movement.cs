using UnityEngine;

public class Movement : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] private PlayerDataSo data;

    [SerializeField] private bool isContinuousMovement = true;

    [Header("Debug: ")]
    [SerializeField] private float moveSpeedPlayer = 1000.0f;


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
            // Movimiento continuo con fisicas
            if (Input.GetKey(data.moveUp))
            {
                rb.AddForce(new Vector3(0, moveSpeedPlayer * Time.fixedDeltaTime));
            }
            if (Input.GetKey(data.moveRight))
            {
                rb.AddForce(new Vector3(moveSpeedPlayer * Time.fixedDeltaTime, 0));
            }
            if (Input.GetKey(data.moveDown))
            {
                rb.AddForce(new Vector3(0, -moveSpeedPlayer * Time.fixedDeltaTime));
            }
            if (Input.GetKey(data.moveLeft))
            {
                rb.AddForce(new Vector3(-moveSpeedPlayer * Time.fixedDeltaTime, 0));
            }
        }
    }
}
