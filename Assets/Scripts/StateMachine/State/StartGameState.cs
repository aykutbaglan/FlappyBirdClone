using Game.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameState : State
{
    [SerializeField] private StartMenu startMenu;
    [SerializeField] private StateMachine stateMachine;
    [SerializeField] private ScoreCanvas _scoreCanvas;
    [SerializeField] private CanvasShopMenu _canvasShopMenu;


    private const int IN_GAME_STATE_INDEX = 1;
    public override void OnEnter()
    {

        base.OnEnter();
        StartGameEnter();
        if (PlayerPrefs.GetInt("isGameRestarted", 0) == 1)
        {
            GameManager.GameResume();
            stateMachine.TransitionToSpecificState(IN_GAME_STATE_INDEX);
            return;
        }

        GameManager.GamePause();
        if (_canvasShopMenu.IsCanvasActive == true)
        {
            canvasGroup.blocksRaycasts = false;
        }
        else
        {
            canvasGroup.blocksRaycasts = true;
        }
        if (_scoreCanvas.IsActiveStartAlpha == true || _canvasShopMenu.IsStartButtonInteractable == true)
        {
            canvasGroup.interactable = false;
        }
        else
        {
            canvasGroup.interactable = true;
        }
    }

    public override void OnExit()
    {
        base.OnExit();
    }
    private void StartGameEnter()
    {
        menu.OnEnter();
        startMenu.OpenStartMenu();
    }
}
