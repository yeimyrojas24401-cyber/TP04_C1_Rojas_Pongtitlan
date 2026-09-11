using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIMainMenu : MonoBehaviour
{
    [Header("Pannels")]
    [SerializeField] private GameObject mainMenuCanvas;
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private GameObject creditsPanel;

    [Header("Buttons")]
    [SerializeField] private Button btnPlay;
    [SerializeField] private Button btnSettings;
    [SerializeField] private Button btnCredits;
    [SerializeField] private Button btnExit;


    private void Awake()
    {
        btnPlay.onClick.AddListener(OnPlayClicked);
        btnSettings.onClick.AddListener(OnSettingsClicked);
        btnCredits.onClick.AddListener(OnCreditsClicked);
        btnExit.onClick.AddListener(OnExitClicked);
    }

    private void OnDestroy()
    {
        btnPlay.onClick.RemoveAllListeners();
        btnSettings.onClick.RemoveAllListeners();
        btnCredits.onClick.RemoveAllListeners();
        btnExit.onClick.RemoveAllListeners();
    }

    private void OnPlayClicked()
    {
        mainMenuCanvas.SetActive(false);
        SceneManager.LoadScene("Gameplay");
    }

    private void OnSettingsClicked()
    {
        mainMenuCanvas.SetActive(false);
        settingsPanel.SetActive(true);
        creditsPanel.SetActive(false);
    }

    private void OnCreditsClicked()
    {
        mainMenuCanvas.SetActive(false);
        settingsPanel.SetActive(false);
        creditsPanel.SetActive(true);
    }

    private void OnExitClicked()
    {
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
