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
    [SerializeField] private ShopButton shopButton;
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
        _scoreCanvas.OnEnter();
        _startMenu.OnExit();
        _endGameMenu.OnExit();
        shopButton.CloseShopButton.SetActive(false);
        _closeScoreButton.SetActive(true);
    }
    public void CloseScoreMenu()
    {
        _scoreCanvas.OnExit();
        _closeScoreButton.SetActive(false);
        _gameManager.GameOver();
        
    }
}
