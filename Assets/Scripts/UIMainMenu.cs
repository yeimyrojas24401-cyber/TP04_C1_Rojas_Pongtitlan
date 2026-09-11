using System;
using UnityEngine;
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
    [SerializeField] private Button btnContinue;
    [SerializeField] private Button btnExit;

    [Header("Data")]
    [SerializeField] private PlayerDataSo data;


    private void Awake()
    {
        btnPlay.onClick.AddListener(OnPlayClicked);
        btnSettings.onClick.AddListener(OnSettingsClicked);
        btnContinue.onClick.AddListener(OnContinueClicked);
        btnExit.onClick.AddListener(OnExitClicked);
    }
    private void Start()
    {
        
    }

    private void OnDestroy()
    {
        btnPlay.onClick.RemoveAllListeners();
        btnSettings.onClick.RemoveAllListeners();
        btnContinue.onClick.RemoveAllListeners();
        btnExit.onClick.RemoveAllListeners();
    }

    private void OnPlayClicked()
    {
        throw new NotImplementedException();
    }

    private void OnSettingsClicked()
    {
        throw new NotImplementedException();
    }

    private void OnContinueClicked()
    {
        throw new NotImplementedException();
    }

    private void OnExitClicked()
    {
        throw new NotImplementedException();
    }




    // Update is called once per frame
    void Update()
    {
        
    }
}
