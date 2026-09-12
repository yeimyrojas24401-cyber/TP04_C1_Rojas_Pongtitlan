using UnityEngine;
[CreateAssetMenu(fileName = "GameSettings", menuName = "Data/Game/GameSettings")]
public class GameSettingsSo : ScriptableObject
{
    [Header("RoundSettings")]
    public int roundsToWin = 3;

    [Header("Time Settings")]
    public float maxTimeOnSide = 5f;
    public float centerX = 0f;
}
