using UnityEngine;
using UnityEngine.UI;

public class SliderRoundsToWin : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] private GameSettingsSo data;
    private Slider sliderRoundsToWin;

    private void Awake()
    {
        sliderRoundsToWin = GetComponent<Slider>();
        sliderRoundsToWin.wholeNumbers = true;
        sliderRoundsToWin.minValue = 0;
        sliderRoundsToWin.maxValue = data.roundsToWinOptions.Length - 1;

        sliderRoundsToWin.onValueChanged.AddListener(OnValueChangedSliderRoundsToWin);
    }

    private void OnEnable()
    {
        sliderRoundsToWin.value = data.roundsToWinIndex;
    }

    private void OnDestroy()
    {
        sliderRoundsToWin.onValueChanged.RemoveAllListeners();
    }

    private void OnValueChangedSliderRoundsToWin(float arg0)
    {
        data.SetRoundsToWinIndex(Mathf.RoundToInt(arg0));
    }
}
