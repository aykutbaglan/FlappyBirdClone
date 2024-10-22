using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.UI
{
    [RequireComponent(typeof(CanvasGroup))]
    public class InGameMenu : Menu
    {
        public bool restartActiveButtons => _canvasGroup.alpha > 0.5f;
        private CanvasGroup _canvasGroup;
        [SerializeField] private StartMenu _startMenu;
        [SerializeField] private EndGameMenu endGameMenu;
        [SerializeField] private ScoreCanvas scoreCanvas;
        [SerializeField] private ShopButton _shopButton;
        [SerializeField] private CanvasMainMenu _canvasMainMenu;
        private void Awake()
        {
            _canvasGroup = GetComponent<CanvasGroup>();
        }
        public void StartGame()
        {
            base.CloseAllMenus();
        }
    }
}