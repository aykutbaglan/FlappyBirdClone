using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.UI
{
    [RequireComponent(typeof(CanvasGroup))]

    public class GoldCanvas : MonoBehaviour
    {
        [SerializeField] private ScoreManager scoreManager;
        private CanvasGroup _canvasGroup;
        private void Awake()
        {
            _canvasGroup = GetComponent<CanvasGroup>();
        }

        public void OpenMenu()
        {
            _canvasGroup.alpha = 1.0f;
            _canvasGroup.blocksRaycasts = true;
            _canvasGroup.interactable = true;
        }
        public void CloseMenu()
        {
            _canvasGroup.alpha = 0f;
            _canvasGroup.blocksRaycasts = false;
            _canvasGroup.interactable = false;
        }
    }
}