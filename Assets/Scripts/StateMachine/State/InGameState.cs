using Game.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameState : State
{
    [SerializeField] private birdController birdController;
    private void Start()
    {
        birdController.enabled = false;
    }

    public override void OnEnter()
    {
        Debug.Log("In Game State On Enter");
        InGameStateEnter();
    }

    public override void OnExit()
    {
        IngameStateExit();
    }
    private void InGameStateEnter()
    {
        menu.OnEnter();
        if (menu._canvasGroup.alpha == 1.0f)
        {
            birdController.enabled = true;
        }
    }
    private void IngameStateExit()
    {
        menu.OnExit();
        birdController.enabled = false;
    }
    private void Update()
    {
        birdController.enabled = menu._canvasGroup.alpha == 1.0f;
    }
}