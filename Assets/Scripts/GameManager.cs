using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerProperties mainPlayer;
    //public StartMenu1 startMenu;
    //public GameObject startMenuGo;
    //public GameObject gameoverMenu;
    public GameObject highScoreTxtGo;
    //public Button startButton;
    public GameObject startButtonGo;
    //public Button restartButton;
    //public GameObject restartButtonGo;
    //public GameObject interactionButtonGo;
    public NameLoginPanel nameLoginPanel;
    public GameObject nameLoginPanelGo;
    public GameObject scoreRankingPanelGo;
    //public GameObject Shop_Birds;
    public Button scoresButton;

    public ScoreBoardManager scoreBoardManager;

    private const string GAME_STARTED = "gameStarted";

    //private void OnEnable()
    //{
    //    scoresButton.onClick.AddListener(OnScoresButtonClicked);
    //    //startButton.onClick.AddListener(OnstartButtonClicked);
    //    //restartButton.onClick.AddListener(OnRestartButtonClicked);
    //}
    private void Start()
    {
        if (nameLoginPanel.inputname.text == "")
        {
            //startButton.interactable = false;
        }
        else
        {
            //startButton.interactable = true;
        }
        if (PlayerPrefs.GetInt(GAME_STARTED, 0) == 0)
        {
            ShowStartMenu();
        }
        else
        {
            StartGame();
        }
    }
    //private void OnDisable()
    //{
    //    scoresButton.onClick.RemoveListener(OnScoresButtonClicked);
    //    //startButton.onClick.RemoveListener(OnstartButtonClicked);
    //    //restartButton.onClick.RemoveListener(OnRestartButtonClicked);
    //}
    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt(GAME_STARTED, 0);
    }
    public void ShowStartMenu() 
    {
        highScoreTxtGo.SetActive(false);
        //startMenuGo.SetActive(true);
        //gameoverMenu.SetActive(false);
        //interactionButtonGo.SetActive(true);
        //startButton.interactable = true;
        Time.timeScale = 0f;
    }
    public void StartGame()
    {
        highScoreTxtGo.SetActive(true);
        //startMenuGo.SetActive(false);
        //gameoverMenu.SetActive(false);
        //interactionButtonGo.SetActive(false);
        Time.timeScale = 1.0f;
        nameLoginPanelGo.SetActive(false);
    }
    public void GameOver()
    {
        //gameoverMenu.SetActive(true);
        //interactionButtonGo.SetActive(true);
        Time.timeScale = 0f;
        scoreBoardManager.ShowNameLoginPanel(mainPlayer.playerScore,mainPlayer.playerName);
        PlayerPrefs.SetInt(GAME_STARTED, 1);
        //if (scoreRankingPanelGo == true || Shop_Birds == true)
        //{
        //    scoreRankingPanelGo.SetActive(false);
        //    Shop_Birds.SetActive(false);
        //    //restartButtonGo.SetActive(false);
        //}
    }
    //public void OpenRankPanel() //Button Onclick te bu fonk çalýþýyor
    //{
    //    scoreRankingPanelGo.SetActive(true);
    //    if (Shop_Birds.activeSelf)
    //    {
    //        startButtonGo.SetActive(false);
    //        Shop_Birds.SetActive(false);
    //        ///*restartButtonGo*/.SetActive(false);
    //    }
    //    if (scoreRankingPanelGo.activeSelf)
    //    {
    //        //restartButtonGo.SetActive(false);
    //        startButtonGo.SetActive(false); 
    //    }
    //    else
    //    {
    //        //restartButtonGo.SetActive(true);
    //        startButtonGo.SetActive(true);
    //    }
    }
    //public void CloseRankingPanel()
    //{
    //    scoreRankingPanelGo.SetActive(false);
    //}
    //public void PanelOrganization()
    //{
    //    if (scoreRankingPanelGo.activeSelf)
    //    {
    //        Shop_Birds.SetActive(false);
    //    }
    //}
    //private void OnScoresButtonClicked()
    //{
    //    if (scoreRankingPanelGo.activeSelf)
    //    {
    //        startButtonGo.SetActive(false);
    //    }
    //    else
    //    {
    //        startButtonGo.SetActive(true);
    //    }
    //}
    ////private void RestartGame()
    ////{
    ////    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    ////}
    //public void OnstartButtonClicked()
    //{
    //    StartGame();
    //}
    //public void OnRestartButtonClicked()
    //{
    //    RestartGame();
    //}

