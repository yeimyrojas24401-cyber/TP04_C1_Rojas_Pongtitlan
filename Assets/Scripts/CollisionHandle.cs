using UnityEngine;

public class CollisionHandle : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;


    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Limits"))
        {
            spriteRenderer.color = Color.gray;
        }
        if (collision.gameObject.CompareTag("Ball"))
        {
            spriteRenderer.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.8f, 1f);
        }
    }

    //entre funcion y funcion se puede poner un espacio en blanco para que se vea mejor
    private void OnCollisionExit2D(Collision2D collision)
    {
        spriteRenderer.color = Color.white;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        PowerUp powerUp = other.GetComponent<PowerUp>();


        if (powerUp != null)
        {
            powerUp.DoAction();

        }
    }
}
