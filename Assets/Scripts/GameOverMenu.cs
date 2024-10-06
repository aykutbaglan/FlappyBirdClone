using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverMenu : MonoBehaviour
{
    public GameManager gameManager;

    private void Start()
    {
        gameManager.restartButtonGo.SetActive(true);
    }
}
