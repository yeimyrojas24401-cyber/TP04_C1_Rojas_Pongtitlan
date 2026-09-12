using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using System.ComponentModel.Design;

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
        isGameOver = false;
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
        Time.timeScale = 1f;
        scoreData.ResetScore();
        SceneManager.LoadScene("MainMenu");
    }

    private void OnExitClicked()
    {
        UnityEditor.EditorApplication.isPlaying = false;
    }

    private void HandleScoreChanged(int  score)
    {
        if (isGameOver) return;
        if (score.Data.leftScore >= settingsData.roundsToWin)
        {
            ShowWin("Player1");
        }
        else if (scoreData.rightScore >= settingsData.roundsToWin)
        {
            ShowWin("Player2");
        }
    }    
    private void ShowWin (string winnerName)
    {
        isGameOver = true;
        winText.text = $"{winnerName} wins!";
        winPanel.SetActive(true);
        Time.timeScale = 0f;
    }

}
