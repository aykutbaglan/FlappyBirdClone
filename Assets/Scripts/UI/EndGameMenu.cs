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
        [SerializeField] private StateMachine stateMachine;
        private void Start()
        {
            CanvasMainMenuControl();
        }
        public void CanvasMainMenuControl()
        {
            if (PlayerPrefs.GetInt("isGameRestarted") == 1)
            {
                _canvasMainMenu.OnExit();
            }
            else
            {
                _canvasMainMenu.OnEnter();
            }
        }
    }
}