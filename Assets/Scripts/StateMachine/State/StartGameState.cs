using Game.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameState : State
{
    [SerializeField] private StartMenu startMenu;
    public override void OnEnter()
    {
        StartGameEnter();
    }

    public override void OnExit()
    {
        menu.OnExit();
    }
    private void StartGameEnter()
    {
        menu.OnEnter();
        startMenu.OpenStartMenu();
    }
}
