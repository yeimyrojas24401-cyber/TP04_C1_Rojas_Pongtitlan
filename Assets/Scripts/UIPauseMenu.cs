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

}
