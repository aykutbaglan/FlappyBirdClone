using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{
    public GameObject startmenu;
    public GameObject highScoreText;
    public birdController birdController;
    public void Start()
    {
        Time.timeScale = 0f;
        startmenu.SetActive(true);
        highScoreText.SetActive(true);
    }
    public void CloseMenu()
    {
        startmenu.SetActive(false);
        highScoreText.SetActive(false);
        Time.timeScale = 1f;
    }
}
