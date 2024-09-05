using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopButton : MonoBehaviour
{
    public GameObject shoppanel;
    public GameObject shopButton;
    public GameObject close;
    public GameObject rankpanel;

    public void ShopOpenButton()
    {
        shoppanel.SetActive(true);
        if (rankpanel.activeSelf)
        {
            rankpanel.SetActive(false);
        }

    }
    public void CloseMenu()
    {
        shoppanel.SetActive(false);
    }
}
