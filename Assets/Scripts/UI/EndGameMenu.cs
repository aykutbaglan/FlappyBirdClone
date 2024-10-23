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
        private void OnEnable()
        {
           _restartButton.onClick.AddListener(OnRestartButtonClicked);
        }
        private void OnDisable()
        {
           _restartButton.onClick.RemoveListener(OnRestartButtonClicked);
        }
        public void OnRestartButtonClicked()
        {
            PlayerPrefs.SetInt("isGameRestarted",1);
            PlayerPrefs.Save();
            _gameManager.gameover = true;
            GameFail = true;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            GameManager.GameResume();
        }
        }
    }