using UnityEngine;

public class Movement : MonoBehaviour
{
    [Header("MovementSettings")]
    [SerializeField] private KeyCode moveUp = KeyCode.W;
    [SerializeField] private KeyCode moveDown = KeyCode.S;
    [SerializeField] private KeyCode moveRight = KeyCode.D;
    [SerializeField] private KeyCode moveLeft = KeyCode.A;

    [Header("SpeedSettings")]
    [SerializeField] private float moveSpeed = 1f;

    [SerializeField] private bool isContinuousMovement = true;

    private Rigidbody2D rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
       if (isContinuousMovement)
        {
            if (Input.GetKey(moveUp))
            {
                rb.AddForce(new Vector3(0,moveSpeed * Time.deltaTime));
            }
            if (Input.GetKey(moveDown))
            {
                rb.AddForce (new Vector3(0, -moveSpeed * Time.deltaTime));
            }
            if (Input.GetKey(moveRight))
            {
                rb.AddForce(new Vector3(moveSpeed * Time.deltaTime, 0));
            }
            if (Input.GetKey(moveLeft))
            {
                rb.AddForce(new Vector3(-moveSpeed * Time.deltaTime, 0));
            }
        }
        else
        {
            if (Input.GetKey(moveUp))
            {
                rb.position += new Vector2 (0, moveSpeed * Time.deltaTime);
            }
            if (Input.GetKey(moveDown))
            {
                rb.position += new Vector2(0, -moveSpeed * Time.deltaTime);
            }
            if (Input.GetKey(moveRight))
            {
                rb.position += new Vector2(moveSpeed * Time.deltaTime, 0);
            }
            if (Input.GetKey(moveLeft))
            {
                rb.position += new Vector2(-moveSpeed * Time.deltaTime, 0);
            } 
        }
    }
}
