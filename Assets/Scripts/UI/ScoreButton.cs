using Game.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreButton : MonoBehaviour
{
    public GameObject _closeScoreButton;
    public GameObject _scoreButtonGo;
    [SerializeField] private Button _scoreButton;
    [SerializeField] private ScoreCanvas _scoreCanvas;
    [SerializeField] private StartMenu _startMenu;
    [SerializeField] private EndGameMenu _endGameMenu;
    [SerializeField] private GameManager _gameManager;

    private void Start()
    {
        _closeScoreButton.SetActive(false);
    }
    private void OnEnable()
    {
        _scoreButton.onClick.AddListener(OpenScoreMenu);
    }
    private void OnDisable()
    {
        _scoreButton.onClick.RemoveListener(OpenScoreMenu);
    }
    public void OpenScoreMenu()
    {
        _scoreCanvas.OpenMenu();
        _startMenu.CloseMenu();
        _endGameMenu.CloseMenu();
        _closeScoreButton.SetActive(true);
    }
    public void CloseScoreMenu()
    {
        _scoreCanvas.CloseMenu();
        _closeScoreButton.SetActive(false);
        _gameManager.GameOver(); //Onclick te bu fonk se�ti�imiz zaman scoreClose Button a t�klad���m�zda startmenu a��l�yor. canvastan se�ince a��lm�yor gameover() yok ��nk�.
        
    }
}
