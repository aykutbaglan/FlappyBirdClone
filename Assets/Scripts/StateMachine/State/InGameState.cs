using UnityEngine;

public class InGameState : State
{
    [SerializeField] private birdController birdController;

    public override void OnEnter()
    {
        base.OnEnter();
        //Debug.Log("In Game State On Enter");
        InGameStateEnter();
        birdController.enabled = true;
    }
    public override void OnExit()
    {
        base.OnExit();
        IngameStateExit();
    }
    private void InGameStateEnter()
    {
        menu.OnEnter();
    }
    private void IngameStateExit()
    {
        menu.OnExit();
        birdController.enabled = false;
    }
}