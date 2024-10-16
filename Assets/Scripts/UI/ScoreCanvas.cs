using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Game.UI
{
    [RequireComponent(typeof(CanvasGroup))]
    public class ScoreCanvas : MonoBehaviour
    {
        public StartMenu startMenu;
        [SerializeField] private CanvasShopMenu _canvasShopMenu;
        [SerializeField] private ScoreButton _scoreButton;
        private CanvasGroup _canvasGroup;
        public bool IsActiveStartAlpha => _canvasGroup.alpha > 0.5f;

        private void Awake()
        {
            _canvasGroup = GetComponent<CanvasGroup>();
        }

        public void OpenMenu()
        {
            _canvasGroup.alpha = 1.0f;
            _canvasGroup.interactable = true;
            _canvasGroup.blocksRaycasts = true;
            _canvasShopMenu.CloseMenu();
        }
        public void CloseMenu()
        {
            _canvasGroup.alpha = 0f;
            _canvasGroup.interactable = false;
            _canvasGroup.blocksRaycasts = false;
            _scoreButton._closeScoreButton.SetActive(false);
        }
    }
}