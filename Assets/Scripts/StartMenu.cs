using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{
    public GameManager gameManager;
    public birdController birdController;
    public ShopManager shopManager;

    public void Start()
    {
        Time.timeScale = 0f;
        gameManager.startMenuGo.SetActive(true);
    }
    public void CloseMenu()
    {
        gameManager.startMenuGo.SetActive(false);
        gameManager.highScoreTxtGo.SetActive(false);
        Time.timeScale = 1f;
        gameManager.interactionButtonGo.SetActive(false);
    }
    public void ClosePanel()
    {
        gameManager.scoreRankingPanelGo.SetActive(false);
        gameManager.Shop_Birds.SetActive(false);
        gameManager.restartButtonGo.SetActive(true);
        for (int i = 0; i < shopManager.buttons.Length; i++)
        {
            if (PlayerPrefs.GetInt("BirdPurchased_" + i) == 1) // Bu acýklanacak!
            {
                gameManager.startButtonGo.SetActive(true);
                return;
            }
            else
            {
                gameManager.startButtonGo.SetActive(false);
            }
        }
    }
}