using Game.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerProperties mainPlayer;
    [SerializeField] private EndGameMenu endGameMenu;
    public StartMenu startMenu;
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
    public bool gameover = false;

    public ScoreBoardManager scoreBoardManager;

    //private const string GAME_STARTED = "isGameStarted";

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
        if (PlayerPrefs.GetInt("isGameStarted", 0) == 0)
        {
            ShowStartMenu();
        }
        else
        {
            StartGame();
        }

        if (!PlayerPrefs.HasKey("isGameRestarted"))
        {
            PlayerPrefs.SetInt("isGameRestarted", 0);
        }
        StartMenu.GameFail = false;
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("isGameStarted", 0);
        PlayerPrefs.DeleteKey("isGameRestarted");
    }
    public static void GamePause()
    {
        Time.timeScale = 0.0f;
    }
    public static void GameResume()
    {
        Time.timeScale = 1.0f;
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
        gameover = true;
        GamePause();
        if (!nameLoginPanel.GetComponent<NameLoginPanel>().isNameSaved)
        {
            scoreBoardManager.ShowNameLoginPanel(mainPlayer.playerScore,mainPlayer.playerName);
        }
        if (StartMenu.GameFail == true)
        {
            endGameMenu.OpenMenu();
            Debug.Log("Oyun Yeniden Baþlatýldý");
        }
        else
        {
            startMenu.OpenMenu();
            Debug.Log("Oyun Ýlk kez baþlatýldý");
        }
    }

    //public void GameOverOLD()
    //{
        
    //    Debug.Log("Game Over");
    //    scoreBoardManager.ShowNameLoginPanel(mainPlayer.playerScore,mainPlayer.playerName);
    //    PlayerPrefs.SetInt(GAME_STARTED, 1);
    //    //gameover = true;
    //    if (StartMenu.GameFail == true)
    //    {
    //        endGameMenu.OpenMenu();
    //        gameover = true;
    //        Debug.Log("Oyun Yeniden Baþlatýldý");
    //    }
    //}
        /* 
         * if (scoreRankingPanelGo == true || Shop_Birds == true)
        {
            scoreRankingPanelGo.SetActive(false);
            Shop_Birds.SetActive(false);
            //restartButtonGo.SetActive(false);
        }*/
    /*
     * public void OpenRankPanel() //Button Onclick te bu fonk çalýþýyor
    //{
    //    scoreRankingPanelGo.SetActive(true);
    //    if (Shop_Birds.activeSelf)
    //    {
    //        startButtonGo.SetActive(false);
    //        Shop_Birds.SetActive(false);
    //        //restartButtonGo.SetActive(false);
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
        } */
}
