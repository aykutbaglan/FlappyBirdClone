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
    private void Update()
    {
        birdController.enabled = menu._canvasGroup.alpha == 1.0f;
    }
}