using Game.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopButton : MonoBehaviour
{
    [SerializeField] private Button _shopButton;
    [SerializeField] private CanvasShopMenu _canvasShopMenu;
    [SerializeField] private CanvasMainMenu _canvasMainMenu;
    [SerializeField] private StartMenu _startMenu;
    [SerializeField] private GameObject CloseShopButton;
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

    public void ShopOpenButton() // burada startmenu.OpenMenu oldu�u i�in endgame de buttonlara bast���m�z zaman startmenu a��l�yor
    {
        _canvasShopMenu.OpenMenu();
        _startMenu.CloseMenu();
        CloseShopButton.SetActive(true);
    }
    public void CloseMenu()
    {
        _canvasShopMenu.CloseMenu();
        CloseShopButton.SetActive(false);
    }
}