using Game.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndingState : State
{
    public static bool GameFail = false;
    public GameObject restartButtonGo;
    [SerializeField] private Button restartButton;
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
        EndingState.GameFail = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        GameManager.GameResume();
    }
}