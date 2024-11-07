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
        [SerializeField] private State inGameState;
        [SerializeField] private StateMachine stateMachine;

        private void Start()
        {
            if (PlayerPrefs.GetInt("isGameRestarted", 1) == 0)
            {
                OpenStartMenu();
            }
            else
            {
                OnExit();
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
        public override void OnEnter()
        {
            base.OnEnter();
        }
        public override void OnExit()
        {
            base.OnExit();
        }
        public void OpenStartMenu()
        {

        }
        private void OnStartButtonClicked()
        {
            Debug.Log("sdaksadldsasda");
            PlayerPrefs.SetInt("isGameStarted", 1);
            PlayerPrefs.Save();
            base.OnExit();
            GameManager.GameResume();
            stateMachine.TransitionToNextState();
            //_canvasMainMenu.OnExit();
            //_inGameMenu.OnEnter();
        }
    }
}