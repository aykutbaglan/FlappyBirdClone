using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverMenu : MonoBehaviour
{
    public GameObject highScoreText;

    private void Start()
    {
        highScoreText.SetActive(true);
    }
}
