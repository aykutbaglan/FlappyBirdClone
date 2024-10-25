using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Game.UI
{
    public class EndGameMenu : Menu
    {
        public Button _restartButton;
        public GameObject restartButtonGo;
        public static bool GameFail = false;
        [SerializeField] private GameManager _gameManager;
        [SerializeField] private CanvasMainMenu _canvasMainMenu;
        [SerializeField] private InGameMenu _inGameMenu;
        private void Start()
        {
            CanvasMainMenuControl();
        }
        private void OnEnable()
        {
           _restartButton.onClick.AddListener(OnRestartButtonClicked);
        }
        private void OnDisable()
        {
           _restartButton.onClick.RemoveListener(OnRestartButtonClicked);
        }
        public void CanvasMainMenuControl()
        {
            if (PlayerPrefs.GetInt("isGameRestarted") == 1)
            {
                _canvasMainMenu.CloseMenu();
            }
            else
            {
                _canvasMainMenu.OpenMenu();
            }
        }
        public void OnRestartButtonClicked()
        {
            PlayerPrefs.SetInt("isGameRestarted",1);
            PlayerPrefs.Save();
            _gameManager.gameover = true;
            GameFail = true;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            GameManager.GameResume();
            _inGameMenu.OpenMenu();
        }

    }
}