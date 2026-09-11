using Unity.VisualScripting;
using UnityEngine;

public class SpriteChanger : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] private PlayerDataSo data;

    private SpriteRenderer spriteRenderer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake ()
    {
        spriteRenderer = GetComponent<SpriteRenderer> ();
    }

    private void Start()
    {
        spriteRenderer.sprite = data.spriter;
    }
}
