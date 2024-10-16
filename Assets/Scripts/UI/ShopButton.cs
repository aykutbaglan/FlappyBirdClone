using Game.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopButton : MonoBehaviour
{
    public GameObject CloseShopButton;
    [SerializeField] private Button _shopButton;
    [SerializeField] private CanvasShopMenu _canvasShopMenu;
    [SerializeField] private CanvasMainMenu _canvasMainMenu;
    [SerializeField] private StartMenu _startMenu;
    [SerializeField] private EndGameMenu _endGameMenu;
    [SerializeField] private GameManager _gameManager;
    private CanvasGroup _canvasGroup;

    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
    }
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
    public void ShopOpenButton() // bu fonksiyon içerisinde CloseButton a bastýðýmda startmenu Alpha sý 0 oluyor.// burada startmenu.OpenMenu olduðu için endgame de buttonlara bastýðýmýz zaman startmenu açýlýyor  
    {// ShopButton a bastýðýmýz zaman StartMenude isek StartMenuyu açsýn EndGame de isek EndGame i açsýn yani alpha yý 1 yapsýn.
        _canvasShopMenu.OpenMenu();
        _startMenu.CloseMenu();
        _endGameMenu.CloseMenu();
        CloseShopButton.SetActive(true);
    }
    public void CloseMenu() 
    {
        _canvasShopMenu.CloseMenu();
        CloseShopButton.SetActive(false);
        _gameManager.GameOver();
    }
}