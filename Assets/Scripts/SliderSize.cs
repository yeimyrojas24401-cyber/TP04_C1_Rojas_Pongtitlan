using System;
using UnityEngine;
using UnityEngine.UI;

public class SliderSize : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] private PlayerDataSo data;

    private Slider sliderSize;

    private void Awake()
    {
        sliderSize = GetComponent<Slider>();

        sliderSize.wholeNumbers = true;
        sliderSize.minValue = 0;
        sliderSize.maxValue = data.variantPrefabs.Length - 1;
        sliderSize.value = data.variantIndex;

        sliderSize.onValueChanged.AddListener(OnValueChangedSliderSize);
    }
    private void OnDestroy()
    {
        sliderSize.onValueChanged.RemoveAllListeners();
    }
    private void OnValueChangedSliderSize(float arg0)
    {
        data.SetVariantIndex(Mathf.RoundToInt(arg0));
    }
}
