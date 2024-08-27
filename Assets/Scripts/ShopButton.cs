using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopButton : MonoBehaviour
{
    public GameObject shoppanel;
    public GameObject shopButton;
    public GameObject close;

    public void ShopOpenButton()
    {
        shoppanel.SetActive(true);
    }
    public void CloseMenu()
    {
        shoppanel.SetActive(false);
    }
}
