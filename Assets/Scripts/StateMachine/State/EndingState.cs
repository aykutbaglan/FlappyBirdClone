using Game.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingState : State
{
    [SerializeField] private EndGameMenu endGameMenu;
    [SerializeField] private NameLoginPanel nameLoginPanel;
    [SerializeField] private ScoreBoardManager scoreBoardManager;
    [SerializeField] private PlayerProperties mainPlayer;
    [SerializeField] private CanvasMainMenu canvasMainMenu;
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
}