using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class SizeLabel : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] private PlayerDataSo data;
    [SerializeField] private TMP_Text label;

    [Header("Labels")]
    [SerializeField] private string[] sizeNames = { "Small", "Medium", "Large" };
    
    private void OnEnable()
    {
        HandleVariantChanged(data.variantIndex);
        data.OnVariantChanged += HandleVariantChanged;
    }
}
