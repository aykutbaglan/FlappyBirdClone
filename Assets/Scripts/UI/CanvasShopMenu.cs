using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace Game.UI
{

    [RequireComponent(typeof(CanvasGroup))]
    public class CanvasShopMenu : MonoBehaviour
    {
        [SerializeField] private ShopButton _shopMenu;
        [SerializeField] private CanvasMainMenu _canvasMainMenu;
        public bool isCanvasActive => _canvasGroup.alpha > 0.5f;


        private CanvasGroup _canvasGroup;

        private void Awake()
        {
            _canvasGroup = GetComponent<CanvasGroup>();
        }
        private void Start()
        {

        }
        public void OpenMenu()
        {
            _canvasGroup.alpha = 1;
            _canvasGroup.interactable = true;
            _canvasGroup.blocksRaycasts = true;
        }
        public void CloseMenu()
        {
            _canvasGroup.alpha = 0;
            _canvasGroup.interactable = false;
            _canvasGroup.blocksRaycasts = false;
        }
    }
}