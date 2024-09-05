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
    public Button startButton;
    public Button restartButton;
    public GameObject interactionButton;

    private const string GAME_STARTED = "gameStarted";

    private void OnEnable()
    {
        startButton.onClick.AddListener(OnstartButtonClicked);
        restartButton.onClick.AddListener(OnRestartButtonClicked);
    }

    private void Start()
    {
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
        startButton.onClick.RemoveListener(OnstartButtonClicked);
        restartButton.onClick.RemoveListener(OnRestartButtonClicked);
    }

    private void OnApplicationQuit()
    {
        Debug.Log("Application Quit");
        PlayerPrefs.SetInt(GAME_STARTED, 0);
    }
    public void ShowStartMenu() 
    {
        startMenu.SetActive(true);
        gameoverMenu.SetActive(false);
        interactionButton.SetActive(true);
        startButton.interactable = true;
        Time.timeScale = 0f;
    }
    public void StartGame()
    {
        startMenu.SetActive(false);
        gameoverMenu.SetActive(false);
        interactionButton.SetActive(false);
        Time.timeScale = 1.0f;
    }
    public void GameOver()
    {
        gameoverMenu.SetActive(true);
        interactionButton.SetActive(true);
        Time.timeScale = 0f;
        Debug.Log("GameOver");
        PlayerPrefs.SetInt(GAME_STARTED, 1);
        if (startmenu.rankPanel == true || startmenu.shopPanel == true)
        {
            startmenu.rankPanel.SetActive(false);
            startmenu.shopPanel.SetActive(false);
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
