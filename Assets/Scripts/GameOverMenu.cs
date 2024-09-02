using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverMenu : MonoBehaviour
{
    public GameObject highScoreText;

    private void Start()
    {
        highScoreText.SetActive(true);
    }
}
