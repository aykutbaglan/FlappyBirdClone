using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{
    public GameObject startmenu;
    public GameObject interactionButton;
    public Button closeButton;
    public GameObject highScoreText;
    public birdController birdController;
    public GameObject rankPanel;
    public GameObject shopPanel;
    public GameObject restartButton;
    public GameObject startButton;

    public void Start()
    {
        Time.timeScale = 0f;
        startmenu.SetActive(true);
        //highScoreText.SetActive(true);
    }
    public void CloseMenu()
    {
        startmenu.SetActive(false);
        highScoreText.SetActive(false);
        Time.timeScale = 1f;
        interactionButton.SetActive(false);
    }
    public void ClosePanel()
    {
        rankPanel.SetActive(false);
        shopPanel.SetActive(false);
        startButton.SetActive(true);
        restartButton.SetActive(true);
    }
}
