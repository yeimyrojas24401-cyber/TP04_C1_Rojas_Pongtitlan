using UnityEngine;

public class PlayerVisualController : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] private PlayerDataSo data;

    private GameObject currentVariantInstance;
    public SpriteRenderer SpriteRenderer { get; private set; }

    private void OnEnable()
    {
        data.OnVariantChanged += HandleVariantChanged;
        data.OnColorChanged += HandleColorChanged;

        SpawnVariant(data.variantIndex);
    }

    private void OnDisable()
    {
        data.OnVariantChanged -= HandleVariantChanged;
        data.OnColorChanged -= HandleColorChanged;
    }

    private void HandleVariantChanged(int index) => SpawnVariant(index);

    private void HandleColorChanged(Color newColor) => ApplyColor();

    // Warning: cada cambio de tamaño destruye el objeto visual e instancia el prefab de la variante nueva. Con tres variantes fijas por jugador, eso son seis prefabs que se crean y se destruyen mientras el jugador mueve el slider.
    // Tenés los tres hijos ya instanciados desde el Awake y activás el que corresponde con SetActive: sin Instantiate ni Destroy, y sin perder la referencia al SpriteRenderer.
    private void SpawnVariant(int index)
    {
        if (currentVariantInstance != null)
        {
            Destroy(currentVariantInstance);
        }

        GameObject prefab = data.CurrentVariant;
        if (prefab == null) return;

        currentVariantInstance = Instantiate(prefab, transform);
        currentVariantInstance.transform.localPosition = Vector3.zero;

        SpriteRenderer = currentVariantInstance.GetComponent<SpriteRenderer>();
        ApplyColor();
    }

    public void ApplyColor()
    {
        if (SpriteRenderer != null)
            SpriteRenderer.color = data.color;
    }
}