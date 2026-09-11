using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField] private PowerUpType powerUpType = PowerUpType.None;

    public void DoAction()
    {
        Debug.Log("PowerUpEnter");

        switch (powerUpType) //nota nunca un powerUpsera none ni last ni default sin embargo lo dejamos
        {
            case PowerUpType.None:
                break;
            case PowerUpType.Size:
                Debug.Log("PowerUp: Size Ejecutado");
                break;
            case PowerUpType.Speed:
                Debug.Log("PowerUp: Speed Ejecutado");
                break;
            case PowerUpType.Last:
                break;
            default:
                break;
        }

    }
}