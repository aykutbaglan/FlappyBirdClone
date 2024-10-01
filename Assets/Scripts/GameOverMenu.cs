using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverMenu : MonoBehaviour
{
    public GameObject highScoreText;
    public ScoreRanking scoreRanking;

    private void Start()
    {
        //highScoreText.SetActive(true);
        scoreRanking.restartButton.SetActive(true);
    }
}
