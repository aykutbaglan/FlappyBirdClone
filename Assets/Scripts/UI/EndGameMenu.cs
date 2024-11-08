using UnityEngine;

namespace Game.UI
{
    public class EndGameMenu : Menu
    {
        [SerializeField] private CanvasMainMenu _canvasMainMenu;
        private void Start()
        {
            CanvasMainMenuControl();
        }
        public void CanvasMainMenuControl()
        {
            if (PlayerPrefs.GetInt("isGameRestarted") == 1)
            {
                _canvasMainMenu.OnExit();
            }
            else
            {
                _canvasMainMenu.OnEnter();
            }
        }
    }
}