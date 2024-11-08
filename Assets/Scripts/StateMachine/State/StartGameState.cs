using Game.UI;
using UnityEngine;
using UnityEngine.UI;
public class StartGameState : State
{
    public Button startButton;
    [SerializeField] private StateMachine stateMachine;
    [SerializeField] private ScoreCanvas _scoreCanvas;
    [SerializeField] private CanvasShopMenu _canvasShopMenu;
    private const int IN_GAME_STATE_INDEX = 1;

    private void OnEnable()
    {
        startButton.onClick.AddListener(OnStartButtonClicked);
    }
    private void OnDisable()
    {
        startButton.onClick.RemoveListener(OnStartButtonClicked);
    }
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
    }
    private void OnStartButtonClicked()
    {
        PlayerPrefs.SetInt("isGameStarted", 1);
        PlayerPrefs.Save();
        base.OnExit();
        GameManager.GameResume();
        stateMachine.TransitionToNextState();
    }
}