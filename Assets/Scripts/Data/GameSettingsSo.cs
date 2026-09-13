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
    public float maxTimeOnSide = 5f;
    public float centerX = 0f;
}
