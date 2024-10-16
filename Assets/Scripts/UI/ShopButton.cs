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
    public void ShopOpenButton() // bu fonksiyon i�erisinde CloseButton a bast���mda startmenu Alpha s� 0 oluyor.// burada startmenu.OpenMenu oldu�u i�in endgame de buttonlara bast���m�z zaman startmenu a��l�yor  
    {// ShopButton a bast���m�z zaman StartMenude isek StartMenuyu a�s�n EndGame de isek EndGame i a�s�n yani alpha y� 1 yaps�n.
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