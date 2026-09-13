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

        sliderColor.wholeNumbers = true;
        sliderColor.minValue = 0;
        sliderColor.maxValue = data.colorOptions.Length - 1;
        sliderColor.value = data.colorIndex;

        sliderColor.onValueChanged.AddListener(OnValueChangedSliderColor);
    }

    private void OnEnable()
    {
        sliderColor.value = data.colorIndex; // sincroniza cada vez que se abre el panel (por el enable)
    }

    private void OnDestroy()
    {
        sliderColor.onValueChanged.RemoveAllListeners();
    }

    private void OnValueChangedSliderColor(float arg0)
    {
        data.SetColorIndex(Mathf.RoundToInt(arg0));
    }
}
