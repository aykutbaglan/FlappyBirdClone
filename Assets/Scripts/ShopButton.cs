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
    public GameObject restartButton;
    public ScoreRanking scoreRanking;

    public void ShopOpenButton()
    {
        if (rankpanel.activeSelf)
        {
            rankpanel.SetActive(false);
        }
        shoppanel.SetActive(true);
        restartButton.SetActive(false);
        scoreRanking.startButton.SetActive(false);
    }
    public void CloseMenu()
    {
        shoppanel.SetActive(false);
        scoreRanking.startButton.SetActive(true);
        restartButton.SetActive(true);
    }
}