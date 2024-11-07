using Game.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public bool gameover = false;
    //[SerializeField] private StartMenu startMenu;
    [SerializeField] private NameLoginPanel nameLoginPanel;
    [SerializeField] private PlayerProperties mainPlayer;
    [SerializeField] private EndGameMenu endGameMenu;
    [SerializeField] private ScoreBoardManager scoreBoardManager;
    //[SerializeField] private InGameMenu _inGameMenu;
    [SerializeField] private CanvasMainMenu _canvasMainMenu;
    [SerializeField] private StateMachine stateMachine;
    [SerializeField] private StartGameState startGameState;
    [SerializeField] private InGameState inGameState;
    [SerializeField] private EndingState endingState;



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
        //if (!nameLoginPanel.GetComponent<NameLoginPanel>().isNameSaved)
        //{
        //    scoreBoardManager.ShowNameLoginPanel(mainPlayer.playerScore,mainPlayer.playerName);
        //}
       // endingState.OnEnter();
        stateMachine.TransitionToNextState();
        if (EndGameMenu.GameFail == true)
        {
            //endGameMenu.OnEnter();
            nameLoginPanel.NameLoginPanelControl();
            _canvasMainMenu.OnEnter();
            //startGameState.OnExit();
            //inGameState.OnExit();
        }
        else
        {
            //startMenu.OpenStartMenu();
        }
    }
    public void AfterSave()
    {
        GamePause();
        //endingState.OnEnter();
       // startGameState.OnExit();
      //  inGameState.OnExit();
        _canvasMainMenu.OnEnter();
    }
}