using System;
using UnityEngine;

[CreateAssetMenu(fileName = "ScoreData", menuName = "Data/Game/ScoreData")] 
public class ScoreDataSo : ScriptableObject
{
    [NonSerialized] public int leftScore;
    [NonSerialized] public int rightScore;

    public event Action<int> OnLeftScoreChanged;
    public event Action<int> OnRightScoreChanged;
    public void AddLeftPoint()
    {
        leftScore++;
        OnLeftScoreChanged?.Invoke(leftScore);
    }
    public void AddRightPoint()
    {
        rightScore++;
        OnRightScoreChanged?.Invoke(rightScore);
    }
    public void ResetScore()
    {
        leftScore = 0;
        rightScore = 0;
        OnLeftScoreChanged?.Invoke(leftScore);
        OnRightScoreChanged?.Invoke(rightScore);
    }    
}
