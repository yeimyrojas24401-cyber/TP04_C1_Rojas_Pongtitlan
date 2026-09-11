using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] private PlayerDataSo data;
    [SerializeField] private PlayerVisualController visual;

    private void Awake ()
    {
        data.OnColorChanged += _ => visual.ApplyColor();
    }
}
