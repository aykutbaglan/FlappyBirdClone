using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public TMP_Text scoreText;
    private int score;
    private int goldScore = 0;
    public TMP_Text highScoreText;
    public TMP_Text goldScoreText;

    private void Start()
    {
        score = 0;
        scoreText.text = score.ToString();
        highScoreText.text = "High Score :" + PlayerPrefs.GetInt("highScore");
        goldScore = PlayerPrefs.GetInt("TotalCoins");
        goldScoreText.text = goldScore.ToString();

    }
    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();

        if (score > PlayerPrefs.GetInt("highScore"))
        {
            PlayerPrefs.SetInt("highScore", score);
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