using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class UIWinMenu : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] private GameSettingsSo settingsData;
    [SerializeField] private GameSettingsSo scoreData;

    [Header("Panels")]
    [SerializeField] private GameObject winPanel;
    [SerializeField] private TMP_Text winText;

    [Header("Buttons")]
    [SerializeField] private Button btnMain;
    [SerializeField] private Button btnExit;

    private bool isGameOver;
        private void Awake()
    {

        btnMain.onClick.AddListener(OnMainClicked);
        btnExit.onClick.AddListener(OnExitClicked);
    }


    private void Start()
    {
        winPanel.SetActive(false);
        Time.timeScale = 1.0f;
    }

    private void Update()
    {
        if (isGameOver)
        {
            return;
        }
    }
    private void OnDestroy()
    {
        btnMain.onClick.RemoveAllListeners();
        btnExit.onClick.RemoveAllListeners();
    }
    private void OnEnable()
    {
        scoreData.OnLeftScoreChanged += HandleScoreChanged;
        scoreData.OnRightScoreChanged += HandleScoreChanged;
    }

    private void OnDisable()
    {
        scoreData.OnLeftScoreChanged -= HandleScoreChanged;
        scoreData.OnRightScoreChanged -= HandleScoreChanged;
    }
    private void OnMainClicked()
    {
        throw new NotImplementedException();
    }

    private void OnExitClicked()
    {
        throw new NotImplementedException();
    }

}
