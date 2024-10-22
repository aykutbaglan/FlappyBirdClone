using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace Game.UI
{

    [RequireComponent(typeof(CanvasGroup))]
    public class CanvasShopMenu : Menu
    {
        public StartMenu startMenu;
        [SerializeField] private ShopButton _shopMenu;
        [SerializeField] private CanvasMainMenu _canvasMainMenu;
        [SerializeField] private ShopButton _shopButton;
        [SerializeField] private ScoreCanvas _scoreCanvas;
        [SerializeField] private GameManager _gameManager;
        public bool IsCanvasActive => _canvasGroup.alpha > 0.5f;
        public bool IsStartButtonInteractable => _canvasGroup.alpha > 0.5f;
        public void ShopButtonCloseOnClick()
        {
            base.CloseAllMenus();
            _gameManager.GameOver();
        }
    }
}