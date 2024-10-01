using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public TMP_Text scoreText;
    private int goldScore = 0;
    public TMP_Text highScoreText;
    public TMP_Text goldScoreText;
    public PlayerProperties mainPlayer;
    private void Start()
    {
        mainPlayer.playerScore = 0;
        scoreText.text = mainPlayer.playerScore.ToString();
        highScoreText.text = "High Score :" + PlayerPrefs.GetInt("highScore");
        goldScore = PlayerPrefs.GetInt("TotalCoins");
        goldScoreText.text = goldScore.ToString();
    }
    public void IncreaseScore()
    {
        mainPlayer.playerScore++;
        scoreText.text = mainPlayer.playerScore.ToString();

        if (mainPlayer.playerScore > PlayerPrefs.GetInt("highScore"))
        {
            PlayerPrefs.SetInt("highScore", mainPlayer.playerScore);
        }
        highScoreText.text = "High Score :" + PlayerPrefs.GetInt("highScore");
    }
    public void IncreaseGoldScore()
    {
        goldScore++;
        PlayerPrefs.SetInt("TotalCoins", goldScore);
        goldScoreText.text = goldScore.ToString();
    }
}