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
    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt(GAME_STARTED, 0);
    }
    public void ShowStartMenu() 
    {
        highScoreTxtGo.SetActive(false);
    }
    public void StartGame()
    {
        highScoreTxtGo.SetActive(true);
        nameLoginPanelGo.SetActive(false);
    }
    public void GameOver()
    {
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
