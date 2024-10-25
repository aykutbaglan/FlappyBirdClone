using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Game.UI
{
    public class StartMenu : Menu
    {
        public Button _startButton;
        [SerializeField] private ScoreCanvas _scoreCanvas;
        [SerializeField] private CanvasShopMenu _canvasShopMenu;
        [SerializeField] private InGameMenu _inGameMenu;
        [SerializeField] private CanvasMainMenu _canvasMainMenu;
        private void Start()
        {
            if (PlayerPrefs.GetInt("isGameRestarted", 1) == 0)
            {
                OpenStartMenu();
            }
            else
            {
                CloseMenu();
            }
        }
        private void OnEnable()
        {
            _startButton.onClick.AddListener(OnStartButtonClicked);
        }
        private void OnDisable()
        {
            _startButton.onClick.RemoveListener(OnStartButtonClicked);
        }
        public void OpenStartMenu()
        {
            if (PlayerPrefs.GetInt("isGameRestarted", 0) == 1)
            {
                GameManager.GameResume();
                _inGameMenu.OpenMenu();
                return;
            }
            base.OpenMenu();
            GameManager.GamePause();
            if (_canvasShopMenu.IsCanvasActive == true)
            {
                _canvasGroup.blocksRaycasts = false;
            }
            else
            {
                _canvasGroup.blocksRaycasts = true;
            }
            if (_scoreCanvas.IsActiveStartAlpha == true || _canvasShopMenu.IsStartButtonInteractable == true)
            {
                _canvasGroup.interactable = false;
            }
            else
            {
                _canvasGroup.interactable = true;
            }
        }
        private void OnStartButtonClicked()
        {
            PlayerPrefs.SetInt("isGameStarted", 1);
            PlayerPrefs.Save();
            base.CloseMenu();
            GameManager.GameResume();
            _canvasMainMenu.CloseMenu();
            _inGameMenu.OpenMenu();
        }
    }
}