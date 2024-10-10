using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Game.UI
{
    [RequireComponent(typeof(CanvasGroup))]
    public class StartMenu : MonoBehaviour
    {
        public static bool isRestarted = false;
        [SerializeField] private Button startButton;
        [SerializeField] private ScoreCanvas scoreCanvas;
        [SerializeField] private CanvasShopMenu _canvasShopMenu;
        private CanvasGroup _canvasGroup;

        private void Awake()
        {
            _canvasGroup = GetComponent<CanvasGroup>();
        }
        private void Start()
        {
            if (!isRestarted)
            {
                OpenMenu();
                Debug.Log("StartMenu Açýldý");
            }
            else
            {
                CloseMenu();
                isRestarted = false;
                Debug.Log("StartMenu Kapatýldý");
            }
        }
        private void OnEnable()
        {
            startButton.onClick.AddListener(OnStartButtonClicked);
        }
        private void OnDisable()
        {
            startButton.onClick.RemoveListener(OnStartButtonClicked);
        }
        public void OpenMenu()
        {
            _canvasGroup.alpha = 1;
            _canvasGroup.interactable = true;
            Time.timeScale = 0f;
            if (_canvasShopMenu.isCanvasActive == true)
            {
                _canvasGroup.blocksRaycasts = false;
                Debug.Log("BlocksRaycasts Deactive");
            }
            else
            {
                _canvasGroup.blocksRaycasts = true;
                Debug.Log("BlocksRaycasts Active");
            }
            
        }
        public void CloseMenu()
        {
            Time.timeScale = 1f;
            _canvasGroup.alpha = 0;
            _canvasGroup.interactable = false;
            _canvasGroup.blocksRaycasts = false;
        }
        
        private void OnStartButtonClicked()
        {
            PlayerPrefs.SetInt("isGameStarted", 1);
            PlayerPrefs.Save();
            CloseMenu();
            Time.timeScale = 1f;
        }
        
        
    }
}