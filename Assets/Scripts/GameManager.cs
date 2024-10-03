using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public StartMenu startmenu;
    public GameObject startMenu;
    public GameObject gameoverMenu;
    public GameObject highScoreTxt;
    public Button startButton;
    public GameObject startButtonn;
    public Button restartButton;
    public GameObject restartButtonn;
    public GameObject interactionButton;
    public PlayerProperties playerProperties;
    public NameLoginPanel nameLoginPanel;
    public GameObject nameLoginPanell;
    public GameObject scoreRankingPanel;
    public GameObject shopPanel;
    public Button scoresButton;

    ScoreBoardManager scoreBoardManager;

    private const string GAME_STARTED = "gameStarted";

    private void OnEnable()
    {
        scoresButton.onClick.AddListener(OnScoresButtonClicked);
        startButton.onClick.AddListener(OnstartButtonClicked);
        restartButton.onClick.AddListener(OnRestartButtonClicked);
    }
    private void Start()
    {
        if (nameLoginPanel.inputname.text == "")
        {
            startButton.interactable = false;
        }
        else
        {
            startButton.interactable = true;
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

    private void OnDisable()
    {
        scoresButton.onClick.RemoveListener(OnScoresButtonClicked);
        startButton.onClick.RemoveListener(OnstartButtonClicked);
        restartButton.onClick.RemoveListener(OnRestartButtonClicked);
    }
    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt(GAME_STARTED, 0);
    }
    public void ShowStartMenu() 
    {
        startMenu.SetActive(true);
        gameoverMenu.SetActive(false);
        interactionButton.SetActive(true);
        startButton.interactable = true;
        Time.timeScale = 0f;
        if(playerProperties.playerName == "")
        if (!PlayerPrefs.HasKey("playerName"))
        {
            //nameLoginPanell.SetActive(true);
        }
        else
        {
            //inputNamePanel.SetActive(false);
        }
    }
    public void StartGame()
    {
        startMenu.SetActive(false);
        gameoverMenu.SetActive(false);
        interactionButton.SetActive(false);
        Time.timeScale = 1.0f;
        nameLoginPanell.SetActive(false);
    }
    public void GameOver()
    {
        gameoverMenu.SetActive(true);
        //highScoreTxt.SetActive(true);
        interactionButton.SetActive(true);
        Time.timeScale = 0f;
        nameLoginPanell.SetActive(true);
        //scoreBoardManager.ShowNameLoginPanel();
        PlayerPrefs.SetInt(GAME_STARTED, 1);
        if (startmenu.rankPanel == true || startmenu.shopPanel == true)
        {
            startmenu.rankPanel.SetActive(false);
            startmenu.shopPanel.SetActive(false);
            restartButtonn.SetActive(false);
        }
    }
    public void OpenRankPanel()
    {
        scoreRankingPanel.SetActive(true);
        if (shopPanel.activeSelf)
        {
            startButtonn.SetActive(false);
            shopPanel.SetActive(false);
            restartButtonn.SetActive(false);
        }
        if (scoreRankingPanel.activeSelf)
        {
            restartButtonn.SetActive(false);
            startButtonn.SetActive(false);
        }
        else
        {
            restartButtonn.SetActive(true);
        }
    }
    public void CloseRankingPanel()
    {
        scoreRankingPanel.SetActive(false);
    }
    public void PanelOrganization()
    {
        if (scoreRankingPanel.activeSelf)
        {
            shopPanel.SetActive(false);
        }
    }
    private void OnScoresButtonClicked()
    {
        if (scoreRankingPanel.activeSelf)
        {
            startButtonn.SetActive(false);
        }
        else
        {
            startButtonn.SetActive(true);
        }
    }
    private void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void OnstartButtonClicked()
    {
        StartGame();
    }
    public void OnRestartButtonClicked()
    {
        RestartGame();
    }
}
