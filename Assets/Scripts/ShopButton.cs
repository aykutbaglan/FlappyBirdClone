using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopButton : MonoBehaviour
{
    public GameManager gameManager;
    public void ShopOpenButton()
    {
        if (gameManager.scoreRankingPanelGo.activeSelf)
        {
            gameManager.scoreRankingPanelGo.SetActive(false);
        }
        gameManager.Shop_Birds.SetActive(true);
        gameManager.restartButtonGo.SetActive(false);
        gameManager.startButtonGo.SetActive(false);
    }
    public void CloseMenu()
    {
        gameManager.Shop_Birds.SetActive(false);
        gameManager.startButtonGo.SetActive(true);
        gameManager.restartButtonGo.SetActive(true);
    }
}