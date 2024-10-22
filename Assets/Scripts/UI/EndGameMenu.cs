using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Game.UI
{
    [RequireComponent(typeof(CanvasGroup))]
    public class EndGameMenu : Menu
    {
        private CanvasGroup _canvasGroup;
        public Button _restartButton;
        public GameObject restartButtonGo;
        [SerializeField] private StartMenu _startMenu;
        [SerializeField] private InGameMenu _inGameMenu;
        [SerializeField] private ScoreCanvas _scoreCanvas;
        [SerializeField] private CanvasShopMenu _shopCanvas;
        [SerializeField] private ShopButton _shopButton;
        [SerializeField] private ScoreButton _scoreButton;
        [SerializeField] private CanvasMainMenu _canvasMainMenu;
        [SerializeField] private GameManager _gameManager;
        private void Awake()
        {
            _canvasGroup = GetComponent<CanvasGroup>();
        }
        //private void Start()
        //{
        //    CloseMenu();
        //}
        private void OnEnable()
        {
                _restartButton.onClick.AddListener(OnRestartButtonClicked);
        }
        private void OnDisable()
        {
                _restartButton.onClick.RemoveListener(OnRestartButtonClicked);
        }
        //public void OpenMenu()
        //{
        //    _canvasGroup.alpha = 1f;
        //    _canvasGroup.interactable = true;
        //    _canvasGroup.blocksRaycasts = true;
        //    //_canvasMainMenu.OpenMenu();
        //    //_inGameMenu.CloseMenu();
        //}
        public void OnRestartButtonClicked()
        {
            PlayerPrefs.SetInt("isGameRestarted",1);
            PlayerPrefs.Save();
            _gameManager.gameover = true;
            StartMenu.GameFail = true;
            _shopButton.CloseMenu();
            _scoreButton.CloseScoreMenu();
            _startMenu.CloseMenu();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            _inGameMenu.OpenMenu();
            GameManager.GameResume();
        }
        //public void CloseMenu()
        //{
        //    _canvasGroup.alpha = 0f;
        //    _canvasGroup.interactable = false;
        //    _canvasGroup.blocksRaycasts = false;
        //}
    }
}