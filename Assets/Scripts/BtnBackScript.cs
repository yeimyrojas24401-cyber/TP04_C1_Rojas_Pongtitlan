using UnityEngine;
using UnityEngine.UI;

public class BtnBackScript : MonoBehaviour
{
    [Header("Panels")]
    [SerializeField] private GameObject currentPanel;
    [SerializeField] private GameObject backPanel;
    private Button backButton;

    private void Awake()
    {
        backButton = GetComponent<Button>();
        backButton.onClick.AddListener(GoBack);

    }
    private void GoBack()
    {
        currentPanel.SetActive(false);
        backPanel.SetActive(true);
    }
}

