using System;
using UnityEngine;
using UnityEngine.UI;

public class SliderSpeed : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] private PlayerDataSo data;
    private Slider sliderSpeed;
    private void Awake()
    {
        sliderSpeed = GetComponent<Slider>();

        //settear el slider desde script 
        sliderSpeed.wholeNumbers = true;
        sliderSpeed.minValue = 0;
        sliderSpeed.maxValue = data.speedOptions.Length - 1;
        sliderSpeed.value = data.speedIndex;

        sliderSpeed.onValueChanged.AddListener(OnValueChangedSliderSpeed);
    }
    private void OnDestroy()
    {
        sliderSpeed.onValueChanged.RemoveAllListeners();
    }
    private void OnValueChangedSliderSpeed(float arg0)
    {
        data.SetSpeedIndex(Mathf.RoundToInt(arg0));
    }
}
