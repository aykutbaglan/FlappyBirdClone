using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Game.UI
{
    [RequireComponent(typeof(CanvasGroup))]
    public class EndGameMenu : MonoBehaviour
    {
        private CanvasGroup _canvasGroup;
        [SerializeField] private Button _restartButton;
        [SerializeField] private StartMenu _startMenu;
        [SerializeField] private InGameMenu _inGameMenu;
        [SerializeField] private ScoreCanvas _scoreCanvas;

        private void Awake()
        {
            _canvasGroup = GetComponent<CanvasGroup>();
        }
        private void Start()
        {
            CloseMenu();
        }
        private void OnEnable()
        {
            if (_restartButton != null)
            {
                _restartButton.onClick.AddListener(OnRestartButtonClicked);
            }
        }
        private void OnDisable()
        {
            if (_restartButton != null)
            {
                _restartButton.onClick.RemoveListener(OnRestartButtonClicked);
            }
        }
        public void OpenMenu()
        {
            Time.timeScale = 0f;
            _canvasGroup.alpha = 1f;
            _canvasGroup.interactable = true;
            _canvasGroup.blocksRaycasts = true;
            _inGameMenu.CloseMenu();
        }
        private void OnRestartButtonClicked()
        {
            StartMenu.isRestarted = true;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        private void CloseMenu()
        {
            Time.timeScale = 1f;
            _canvasGroup.alpha = 0f;
            _canvasGroup.interactable = false;
            _canvasGroup.blocksRaycasts = false;
        }
    }
}