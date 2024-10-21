using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace Game.UI
{
    [RequireComponent(typeof(CanvasGroup))]

    public class CanvasMainMenu : MonoBehaviour
    {
        [SerializeField] private StartMenu _startMenu;
        [SerializeField] private CanvasShopMenu _canvasShopMenu;
        [SerializeField] private ScoreCanvas _canvasScoreMenu;
        public CanvasGroup _canvasGroup;

        private void Awake()
        {
            _canvasGroup = GetComponent<CanvasGroup>();
        }
        public void OpenMenu()
        {
            _canvasGroup.alpha = 1.0f;
            _canvasGroup.interactable = true;
            _canvasGroup.blocksRaycasts = true;
            _startMenu.CloseMenu();
        }
        public void RestartGameButtonsOff()
        {
            _canvasGroup.alpha = 0f;
            _canvasGroup.interactable = false;
            _canvasGroup.blocksRaycasts = false;
        }
        private void CloseMenu()
        {
            _canvasGroup.alpha = 0f;
            _canvasGroup.interactable = false;
            _canvasGroup.blocksRaycasts = false;
            _startMenu.OpenMenu();
        }
        private void CloseButton()
        {
            _canvasShopMenu.CloseMenu();
            _canvasScoreMenu.CloseMenu();
            _startMenu.OpenMenu();
        }
        
    }
}