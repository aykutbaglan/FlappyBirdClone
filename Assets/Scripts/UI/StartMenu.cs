using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Game.UI
{
    [RequireComponent(typeof(CanvasGroup))]
    public class StartMenu : Menu
    {
        public static bool GameFail = false;
        public Button _startButton;
        public GameObject startButton;
        [SerializeField] private ScoreCanvas _scoreCanvas;
        [SerializeField] private CanvasShopMenu _canvasShopMenu;
        [SerializeField] private InGameMenu _inGameMenu;
        private CanvasGroup _canvasGroup;

        private void Awake()
        {
            _canvasGroup = GetComponent<CanvasGroup>();
        }
        private void Start()
        {
            if (PlayerPrefs.GetInt("isGameRestarted", 1) == 0)
            {
                OpenMenu();
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
        public void OpenMenu()
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
            _inGameMenu.OpenMenu();
            CloseMenu();
            GameManager.GameResume();
        }
    }
}