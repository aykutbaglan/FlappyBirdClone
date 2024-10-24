using Game.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public bool gameover = false;
    [SerializeField] private StartMenu startMenu;
    [SerializeField] private NameLoginPanel nameLoginPanel;
    [SerializeField] private PlayerProperties mainPlayer;
    [SerializeField] private EndGameMenu endGameMenu;
    [SerializeField] private ScoreBoardManager scoreBoardManager;
    [SerializeField] private InGameMenu _inGameMenu;

    private void Start()
    {
        if (!PlayerPrefs.HasKey("isGameRestarted"))
        {
            PlayerPrefs.SetInt("isGameRestarted", 0);
        }
        EndGameMenu.GameFail = false;
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
    public void GameOver()
    {
        gameover = true;
        GamePause();
        nameLoginPanel.NameLoginPanelControl();
        if (!nameLoginPanel.GetComponent<NameLoginPanel>().isNameSaved)
        {
            scoreBoardManager.ShowNameLoginPanel(mainPlayer.playerScore,mainPlayer.playerName);
        }

        if (EndGameMenu.GameFail == true)
        {
            endGameMenu.OpenMenu();
            startMenu.CloseMenu();
            _inGameMenu.CloseMenu();
        }
        else
        {
            startMenu.OpenMenu();
        }
    }
}