using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.UI
{
    [RequireComponent(typeof(CanvasGroup))]
    public class Menu : MonoBehaviour
    {
        public CanvasGroup _canvasGroup;
        public Menu[] menus;
        private void Awake()
        {
            _canvasGroup = GetComponent<CanvasGroup>();
        }
        public void OpenMenu()
        {
            CloseAllMenus();
            _canvasGroup.alpha = 1.0f;
            _canvasGroup.blocksRaycasts = true;
            _canvasGroup.interactable = true;
        }
        public void CloseMenu()
        {
            _canvasGroup.alpha = 0.0f;
            _canvasGroup.blocksRaycasts = false;
            _canvasGroup.interactable = false;
        }
        public void CloseAllMenus()
        {
            for (int i = 0; i < menus.Length; i++)
            {
                menus[i].CloseMenu();
            }
        }
        
    }
}