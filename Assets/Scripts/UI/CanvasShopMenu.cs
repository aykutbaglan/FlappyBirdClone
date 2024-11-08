using UnityEngine;
namespace Game.UI
{
    [RequireComponent(typeof(CanvasGroup))]
    public class CanvasShopMenu : Menu
    {
        [SerializeField] private StartMenu startMenu;
        [SerializeField] private ShopButton _shopButton;
        [SerializeField] private GameManager _gameManager;
        [SerializeField] private EndingState endingState;
        public bool IsCanvasActive => _canvasGroup.alpha > 0.5f;
        public bool IsStartButtonInteractable => _canvasGroup.alpha > 0.5f;
        public void ShopButtonCloseOnClick()
        {
            base.CloseAllMenus();
            _shopButton.CloseShopButton.SetActive(false);
            if (_gameManager.gameover)
            {
                endingState.OnEnter();
            }
            else
            {
                startMenu.OnEnter();
            }
        }
    }
}