using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{
    public GameObject startmenu;
    public void Start()
    {
        Time.timeScale = 0f;
        startmenu.SetActive(true);
    }
    public void CloseMenu()
    {
        startmenu.SetActive(false);
        Time.timeScale = 1f;
    }
}
