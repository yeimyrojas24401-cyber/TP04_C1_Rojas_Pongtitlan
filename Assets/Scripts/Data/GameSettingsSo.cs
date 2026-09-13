using System;
using UnityEngine;
[CreateAssetMenu(fileName = "GameSettings", menuName = "Data/Game/GameSettings")]
public class GameSettingsSo : ScriptableObject
{
    [Header("RoundSettings")]

    public int[] roundsToWinOptions = {2,3,4};
    [NonSerialized] public int roundsToWinIndex = 1;

    public int rounds
    {
        get
        {
            if (roundsToWinOptions != null && roundsToWinOptions.Length > 0)
            {
                return roundsToWinOptions[Mathf.Clamp(roundsToWinIndex, 0, roundsToWinOptions.Length - 1)];
            }
            else
            {
                return 0;
            }
        }
    }
    public event Action<int> OnRoundsToWinChanged;
    public void SetRoundsToWinIndex (int index)
    {
        if (roundsToWinOptions == null || roundsToWinOptions.Length == 0) return;
        roundsToWinIndex = Mathf.Clamp(index, 0, roundsToWinOptions.Length - 1);
        OnRoundsToWinChanged?.Invoke(rounds);
    }

    [Header("Time Settings")]

    public float[] maxTimeOnSideOptions = { 5f, 10f, 20f};
    [NonSerialized] public int maxTimeOnSideIndex = 1; 
    public float time
    {
        get
        {
            if (maxTimeOnSideOptions != null && maxTimeOnSideOptions.Length > 0)
            {
                return maxTimeOnSideOptions[Mathf.Clamp(maxTimeOnSideIndex, 0, maxTimeOnSideOptions.Length - 1)];
            }
            else
            {
                return 0;
            }
        }
    }
    public event Action<float> OnTimeOnSideChanged;
    public void SetMaxTimeOnSideIndex (int index)
    {
        if (maxTimeOnSideOptions == null || maxTimeOnSideOptions.Length == 0) return;
        maxTimeOnSideIndex = Mathf.Clamp(index, 0, maxTimeOnSideOptions.Length - 1);
        OnTimeOnSideChanged?.Invoke(time);
    }

    public float centerX = 0f;
}
