using UnityEngine;
[CreateAssetMenu(fileName = "PlayerData", menuName = "Data/Game/PlayerData")]
public class PlayerDataSo : ScriptableObject
{
    [Header("MovementSettings")]
    public KeyCode moveUp = KeyCode.W;
    public KeyCode moveDown = KeyCode.S;
    public KeyCode moveRight = KeyCode.D;
    public KeyCode moveLeft = KeyCode.A;

    [Header("SpeedSettings")]
    [Range(1,3)] public float speed = 1.0f;

    [Header("VisualSettings")]
    public Sprite spriter;
    public Color color = Color.white;
}
