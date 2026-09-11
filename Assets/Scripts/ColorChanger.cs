using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] private PlayerDataSo data;

    private SpriteRenderer spriteRenderer;

    private void Awake ()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Start()
    {
        spriteRenderer.color = data.color;
    }
}
