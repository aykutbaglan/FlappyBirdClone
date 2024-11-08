using Game.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndingState : State
{
    public GameObject restartButtonGo;
    [SerializeField] private Button restartButton;
    [SerializeField] private EndGameMenu endGameMenu;
    [SerializeField] private NameLoginPanel nameLoginPanel;
    [SerializeField] private ScoreBoardManager scoreBoardManager;
    [SerializeField] private PlayerProperties mainPlayer;
    [SerializeField] private CanvasMainMenu canvasMainMenu;
    [SerializeField] private GameManager gameManager;
    private void OnEnable()
    {
        restartButton.onClick.AddListener(OnRestartButtonClicked);
    }
    private void OnDisable()
    {
        restartButton.onClick.RemoveListener(OnRestartButtonClicked);
    }
    public override void OnEnter()
    {
        base.OnEnter();
        EndingStateEnter();
        if (!nameLoginPanel.GetComponent<NameLoginPanel>().isNameSaved)
        {
            scoreBoardManager.ShowNameLoginPanel(mainPlayer.playerScore, mainPlayer.playerName);
        }
    }

    public override void OnExit()
    {
        base.OnExit();
    }
    private void EndingStateEnter()
    {
        menu.OnEnter();
        canvasMainMenu.OnEnter();
    }
    public void OnRestartButtonClicked()
    {
        PlayerPrefs.SetInt("isGameRestarted", 1);
        PlayerPrefs.Save();
        gameManager.gameover = true;
        EndGameMenu.GameFail = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        GameManager.GameResume();
    }
}