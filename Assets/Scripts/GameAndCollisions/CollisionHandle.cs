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
            // Suggestion: la consigna del TP04 pide que al golpear un límite de pantalla el color sea Negro, y acá es Color.gray.
            // Es cambiar una palabra.
            visual.SpriteRenderer.color = Color.gray;

        if (collision.gameObject.GetComponent<BallMarker>() != null)
            visual.SpriteRenderer.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.8f, 1f);
        // Warning: la velocidad se pone en cero en CUALQUIER colisión, no solo contra la pelota: también contra los límites de arriba y abajo y contra las zonas de gol.
        // El comentario dice que es para que la pelota no empuje al jugador, pero para eso alcanza con chequear el BallMarker (que ya hacés tres líneas más arriba), o con subirle la masa al Rigidbody2D de la paleta.
        rb.linearVelocity = Vector2.zero; // esto nos permite que cuando la pelota vaya a pegarle al 
                                          //se cancela la velocida y ya no empuja al jugador

    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<LimitMarker>() != null)
        {
            // Bug: al salir del límite la paleta vuelve a blanco fijo, no al color que el jugador eligió en settings. PlayerDataP1.asset arranca en verde, así que después del primer roce contra un borde el jugador 1 queda blanco para siempre.
            // Llamá a visual.ApplyColor(), que ya existe en PlayerVisualController y pone exactamente el color del ScriptableObject.
            visual.SpriteRenderer.color = Color.white;
        }
    }

    // Suggestion: quedaron once líneas comentadas con el enganche de los power ups.
    // Si el sistema no llegó, borralas: el historial de git ya guarda lo que descartaste.
    //private void OnTriggerEnter2D(Collider2D other)
    //{
    //    PowerUp powerUp = other.GetComponent<PowerUp>();


    //    if (powerUp != null)
    //    {
    //        powerUp.DoAction();

    //    }
    //}
}
