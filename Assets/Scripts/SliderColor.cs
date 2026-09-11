using System;
using UnityEngine;
using UnityEngine.UI;

public class SliderColor : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] private PlayerDataSo data;
    private Slider sliderColor;
    private void Awake()
    {
        sliderColor = GetComponent<Slider>();
        sliderColor.onValueChanged.AddListener(OnValueChangedSliderColor);
    }

    private void OnDestroy()
    {
        sliderColor.onValueChanged.RemoveAllListeners();
    }
    private void OnValueChangedSliderColor(float arg0)
    {
        if (sliderColor.value == 1)
        {
            data.color = Color.white;
        }
        if (sliderColor.value == 2)
        {
            data.color = Color.green;
        }
        if (sliderColor.value == 3)
        {
            data.color = Color.blue;
        }
    }
}
