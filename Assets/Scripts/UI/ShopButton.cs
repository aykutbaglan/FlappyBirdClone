using Game.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopButton : MonoBehaviour
{
    public GameObject CloseShopButton;
    public GameObject shopButtonGo;
    [SerializeField] private Button _shopButton;
    [SerializeField] private ScoreButton scoreButton;
    [SerializeField] private CanvasShopMenu _canvasShopMenu;
    [SerializeField] private CanvasMainMenu _canvasMainMenu;
    [SerializeField] private StartMenu _startMenu;
    [SerializeField] private EndGameMenu _endGameMenu;
    [SerializeField] private GameManager _gameManager;

    private void Start()
    {
        CloseShopButton.SetActive(false);   
    }
    private void OnEnable()
    {
        _shopButton.onClick.AddListener(ShopOpenButton);
    }
    private void OnDisable()
    {
        _shopButton.onClick.RemoveListener(ShopOpenButton);
    }
    public void ShopOpenButton()
    { 
        _canvasShopMenu.OnEnter();
        _startMenu.OnExit();
        _endGameMenu.OnExit();
        scoreButton._closeScoreButton.SetActive(false);
        CloseShopButton.SetActive(true);
    }
    public void CloseMenu() 
    {
        _canvasShopMenu.OnExit();
        CloseShopButton.SetActive(false);
        _gameManager.GameOver();
    }
}