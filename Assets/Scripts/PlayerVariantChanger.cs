using UnityEngine;

public class PlayerVariantChanger: MonoBehaviour
{
    [Header("Data")]
    [SerializeField] private PlayerDataSo data;

    private GameObject currentInstance;

    private void OnEnable()
    {
        SpawnVariant(data.variantIndex);
        data.OnVariantChanged += HandleVariantChanged;
    }

    private void OnDisable()
    {
        data.OnVariantChanged -= HandleVariantChanged;
    }

    private void HandleVariantChanged(int index)
    {
        SpawnVariant(index);
    }

    private void SpawnVariant(int index)
    {
        if (currentInstance != null)
            Destroy(currentInstance);

        GameObject prefab = data.CurrentVariant;
        if (prefab == null) return;

        currentInstance = Instantiate(prefab, transform.position, transform.rotation, transform);
    }
}