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
        sliderSize.onValueChanged.AddListener(OnValueChangedSliderSize);
    }
    private void OnDestroy()
    {
        sliderSize.onValueChanged.RemoveAllListeners();
    }
    private void OnValueChangedSliderSize(float arg0)
    {
        //data.spriter = ;
    }
}
