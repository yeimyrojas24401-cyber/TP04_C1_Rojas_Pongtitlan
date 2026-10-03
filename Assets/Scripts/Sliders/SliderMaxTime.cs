using System;
using UnityEngine;
using UnityEngine.UI;

public class SliderMaxTime : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] private GameSettingsSo data;
    private Slider sliderTime;
    private void Awake()
    {
        sliderTime = GetComponent<Slider>();
        sliderTime.wholeNumbers = true;
        sliderTime.minValue = 0;
        sliderTime.maxValue = data.maxTimeOnSideOptions.Length - 1;
        sliderTime.value = data.maxTimeOnSideIndex;

        sliderTime.onValueChanged.AddListener(OnValueChangedSliderTime);
    }

    private void OnEnable()
    {
        sliderTime.value = data.maxTimeOnSideIndex;
    }
    private void OnDestroy()
    {
        sliderTime.onValueChanged.RemoveAllListeners();
    }
    private void OnValueChangedSliderTime(float arg0)
    {
        data.SetMaxTimeOnSideIndex(Mathf.RoundToInt(arg0));
    }
}
