using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Game.UI
{
    [RequireComponent(typeof(CanvasGroup))]
    public class ScoreCanvas : Menu
    {
        public StartMenu startMenu;
        [SerializeField] private CanvasShopMenu _canvasShopMenu;
        [SerializeField] private ScoreButton _scoreButton;
        [SerializeField] private GameManager _gameManager;
        public bool IsActiveStartAlpha => _canvasGroup.alpha > 0.5f;

        public void ScoreButtonCloseOnclick()
        {
            base.CloseAllMenus();
            _scoreButton._closeScoreButton.SetActive(false);
            //_gameManager.GameOver();
            startMenu.OnEnter();
        }
    }
}