using UnityEngine;

public class PlayerVisualController : MonoBehaviour
{
    [SerializeField] private PlayerDataSo data;

    private GameObject currentVariantInstance;
    public SpriteRenderer SpriteRenderer { get; private set; }

    private void Awake()
    {
        data.OnVariantChanged += HandleVariantChanged;
    }

    private void Start()
    {
        SpawnVariant(data.variantIndex);
    }

    private void OnDestroy()
    {
        data.OnVariantChanged -= HandleVariantChanged;
    }

    private void HandleVariantChanged(int index) => SpawnVariant(index);

    private void SpawnVariant(int index)
    {
        if (currentVariantInstance != null)
            Destroy(currentVariantInstance);

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
