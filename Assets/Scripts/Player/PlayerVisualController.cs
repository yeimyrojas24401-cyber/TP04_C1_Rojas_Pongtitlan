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