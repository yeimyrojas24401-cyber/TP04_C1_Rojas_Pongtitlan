using System;
using UnityEngine;
using UnityEngine.UI;

public class SliderSpeed : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] private PlayerDataSo data;
    private Slider sliderP1Speed;
    private void Awake()
    {
        sliderP1Speed = GetComponent<Slider>();
        sliderP1Speed.onValueChanged.AddListener(OnValueChangedSliderP1Speed);
    }
    private void OnDestroy()
    {
        sliderP1Speed.onValueChanged.RemoveAllListeners();
    }
    private void OnValueChangedSliderP1Speed(float arg0)
    {
        data.speed = arg0;
    }
}
