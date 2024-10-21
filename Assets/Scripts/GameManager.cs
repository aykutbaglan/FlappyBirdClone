using Game.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public StartMenu startMenu;
    public GameObject highScoreTxtGo;
    public GameObject startButtonGo;
    public NameLoginPanel nameLoginPanel;
    public GameObject nameLoginPanelGo;
    //public GameObject scoreRankingPanelGo;
    public bool gameover = false;
    [SerializeField] private PlayerProperties mainPlayer;
    [SerializeField] private EndGameMenu endGameMenu;
    [SerializeField] private ScoreBoardManager scoreBoardManager;
    [SerializeField] private ScoreButton _scoreButton;
    [SerializeField] private ShopButton _shopButton;

    //private const string GAME_STARTED = "isGameStarted";

    private void Start()
    {
        //if (nameLoginPanel.inputname.text == "")
        //{
        //    //startButton.interactable = false;
        //}
        //else
        //{
        //    //startButton.interactable = true;
        //}
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
    //public void NameLoginPanelActiveted()
    //{
    //    if (nameLoginPanelGo.activeSelf == true)
    //    {
    //        endGameMenu.restartButtonGo.SetActive(false);
    //        _scoreButton._scoreButtonGo.SetActive(false);
    //        _shopButton.shopButtonGo.SetActive(false);
    //        Debug.Log("NameLoginPaneli Açýldý");
    //    }
    //    else
    //    {
    //        endGameMenu.restartButtonGo.SetActive(true);
    //        _scoreButton._scoreButtonGo.SetActive(true);
    //        _shopButton.shopButtonGo.SetActive(true);
    //        Debug.Log("NameLoginPaneli Kapandý");
    //    }
    //}
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
        if (nameLoginPanelGo.activeSelf == true)
        {
            endGameMenu.restartButtonGo.SetActive(false);
            _scoreButton._scoreButtonGo.SetActive(false);
            _shopButton.shopButtonGo.SetActive(false);
            Debug.Log("NameLoginPaneli Açýldý");
        }
        else
        {
            endGameMenu.restartButtonGo.SetActive(true);
            _scoreButton._scoreButtonGo.SetActive(true);
            _shopButton.shopButtonGo.SetActive(true);
            Debug.Log("NameLoginPaneli Kapandý");
        }
    }
}