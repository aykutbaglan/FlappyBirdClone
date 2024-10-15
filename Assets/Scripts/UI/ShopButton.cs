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
    private CanvasGroup _canvasGroup;

    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
    }
    public void ShopOpenButton() // burada startmenu.OpenMenu olduðu için endgame de buttonlara bastýðýmýz zaman startmenu açýlýyor
    {
        _canvasShopMenu.OpenMenu();
        _startMenu.CloseMenu();
    }
    public void CloseMenu()
    {
        _canvasShopMenu.CloseMenu();
    }
}