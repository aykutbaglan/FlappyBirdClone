using UnityEngine;

namespace Game.UI
{
    [RequireComponent(typeof(CanvasGroup))]
    public class ScoreCanvas : Menu
    {
        [SerializeField] private StartMenu startMenu;
        [SerializeField] private ScoreButton _scoreButton;
        [SerializeField] private GameManager _gameManager;
        [SerializeField] protected EndingState endingState;
        public bool IsActiveStartAlpha => _canvasGroup.alpha > 0.5f;

        public void ScoreButtonCloseOnclick()
        {
            base.CloseAllMenus();
            _scoreButton._closeScoreButton.SetActive(false);
            if (_gameManager.gameover)
            {
                endingState.OnEnter();
            }
            else
            {
                startMenu.OnEnter();
            }
        }
    }
}