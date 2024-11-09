using Game.UI;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool gameover = false;
    [SerializeField] private NameLoginPanel nameLoginPanel;
    [SerializeField] private PlayerProperties mainPlayer;
    [SerializeField] private EndGameMenu endGameMenu;
    [SerializeField] private ScoreBoardManager scoreBoardManager;
    [SerializeField] private CanvasMainMenu _canvasMainMenu;
    [SerializeField] private StateMachine stateMachine;
    [SerializeField] private StartState startState;
    [SerializeField] private InGameState inGameState;
    [SerializeField] private EndingState endingState;

    private void Start()
    {
        if (!PlayerPrefs.HasKey("isGameRestarted"))
        {
            PlayerPrefs.SetInt("isGameRestarted", 0);
        }
        EndingState.GameFail = false;
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
        stateMachine.TransitionToNextState();
        if (EndingState.GameFail == true)
        {
            nameLoginPanel.NameLoginPanelControl();
            _canvasMainMenu.OnEnter();
        }
    }
    public void AfterSave()
    {
        GamePause();
        _canvasMainMenu.OnEnter();
    }
}