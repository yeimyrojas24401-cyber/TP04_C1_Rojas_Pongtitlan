using UnityEngine;

public class CollisionHandle : MonoBehaviour
{
    [SerializeField] private PlayerVisualController visual;
    private Rigidbody2D rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (visual.SpriteRenderer == null) return;

        if (collision.gameObject.GetComponent<LimitMarker>() != null)
            visual.SpriteRenderer.color = Color.gray;

        if (collision.gameObject.GetComponent<BallMarker>() != null)
            visual.SpriteRenderer.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.8f, 1f);
        rb.linearVelocity = Vector2.zero; // esto nos permite que cuando la pelota vaya a pegarle al 
                                          //se cancela la velocida y ya no empuja al jugador

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
