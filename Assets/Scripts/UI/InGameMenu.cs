using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.UI
{
    [RequireComponent(typeof(CanvasGroup))]
    public class InGameMenu : MonoBehaviour
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
        private void Start()
        {
            scoreCanvas.CloseMenu();
            _shopButton.CloseMenu();
        }
        public void OpenMenu()
        {
            _canvasGroup.alpha = 1;
            _canvasGroup.interactable = true;
            _canvasGroup.blocksRaycasts = true;
            _canvasMainMenu.RestartGameButtonsOff();
        }
        public void CloseMenu()
        {
            _canvasGroup.alpha = 0;
            _canvasGroup.interactable = false;
            _canvasGroup.blocksRaycasts = false;
        }
    }
}