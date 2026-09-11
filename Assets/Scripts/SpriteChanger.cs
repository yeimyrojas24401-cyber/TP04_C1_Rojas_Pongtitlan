using Unity.VisualScripting;
using UnityEngine;

public class SpriteChanger : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] private PlayerDataSo data;

    private SpriteRenderer spriteRenderer;

    private void Awake ()
    {
        spriteRenderer = GetComponent<SpriteRenderer> ();
    }

    private void Start()
    {
        spriteRenderer.sprite = data.spriter;
    }
}
