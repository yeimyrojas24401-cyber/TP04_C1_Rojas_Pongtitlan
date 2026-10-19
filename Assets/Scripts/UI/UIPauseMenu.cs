using System;
using UnityEngine;
using UnityEngine.UI;

public class UIPauseMenu : MonoBehaviour
{
    [Header("Panels")]
    [SerializeField] private GameObject creditsPanel;
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private GameObject pausePanel;

    [Header("Buttons")]
    [SerializeField] private Button btnContinue;
    [SerializeField] private Button btnSettings;
    [SerializeField] private Button btnCredits;
    [SerializeField] private Button btnExit;

    private bool isPause = false;

    private void Awake()
    {
        btnContinue.onClick.AddListener(OnContinueClicked);
        btnSettings.onClick.AddListener(OnSettingsClicked);
        btnCredits.onClick.AddListener(OnCreditsClicked);
        btnExit.onClick.AddListener(OnExitClicked);

#if UNITY_WEBGL && !UNITY_EDITOR
    btnExit.gameObject.SetActive(false);
#endif
    }
    private void Start()
    {
        pausePanel.SetActive(false);
        settingsPanel.SetActive(false);
        creditsPanel.SetActive(false);
    }
    private void OnDestroy()
    {
        // Warning: RemoveAllListeners borra también lo que alguien haya cableado desde el inspector, no solo lo que registraste en el Awake. Está repetido en UIMainMenu, UIWinMenu y BtnBackScript.
        // Como registrás con AddListener(OnContinueClicked), dá de baja con RemoveListener(OnContinueClicked).
        btnContinue.onClick.RemoveAllListeners();
        btnSettings.onClick.RemoveAllListeners();
        btnCredits.onClick.RemoveAllListeners();
        btnExit.onClick.RemoveAllListeners();
    }

    private void Update()
    {
        // Bug: Escape llama siempre a OnContinueClicked, que togglea isPause. Si estás con el panel de settings o el de créditos abiertos (donde pausePanel ya está apagado pero isPause sigue en true), un Escape pone isPause en false y timeScale en 1: el juego arranca a correr con el panel de settings encima.
        // Que Escape primero cierre el submenú abierto y vuelva al panel de pausa, y solo despause cuando el que está visible es el panel de pausa.
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OnContinueClicked();
        }
    }
    private void OnContinueClicked()
    {
        isPause = !isPause; //!igual a lo opuesto
        pausePanel.SetActive(isPause);
        if (isPause)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }

    private void OnSettingsClicked()
    {
        settingsPanel.SetActive(true);
        creditsPanel.SetActive(false);
        pausePanel.SetActive(false);
    }

    private void OnCreditsClicked()
    {
        creditsPanel.SetActive(true);
        settingsPanel.SetActive(false);
        pausePanel.SetActive(false);
    }

    private void OnExitClicked()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
    Application.Quit();
#endif
    }
}
