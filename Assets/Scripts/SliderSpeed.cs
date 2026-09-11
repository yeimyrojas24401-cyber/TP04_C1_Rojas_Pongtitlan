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
        sliderSpeed.onValueChanged.AddListener(OnValueChangedSliderSpeed);
    }
    private void OnDestroy()
    {
        sliderSpeed.onValueChanged.RemoveAllListeners();
    }
    private void OnValueChangedSliderSpeed(float arg0)
    {
        data.SetSpeed(arg0);
    }
}
