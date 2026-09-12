using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class UIWinMenu : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] private GameSettingsSo settingsData;
    [SerializeField] private ScoreDataSo scoreData;

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

    private void HandleScoreChanged(int  score)
    {
        if (isGameOver) return;
        if (scoreData.leftScore >= settingsData.roundsToWin)
        {
            ShowWin("Player 1");
        }
        else if (scoreData.rightScore >= settingsData.roundsToWin)
        {
            ShowWin("Player 2");
        }
    }    
    private void ShowWin (string winnerName)
    {
        isGameOver = true;
        winText.text = $"{winnerName}";
        winPanel.SetActive(true);
        Time.timeScale = 0f;
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

}
