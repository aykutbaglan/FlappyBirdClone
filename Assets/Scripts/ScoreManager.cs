using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public PlayerProperties mainPlayer;
    [SerializeField] public TMP_Text goldScoreText;
    [SerializeField] private TMP_Text scoreText;
    private int goldScore = 0;
    
    private void Start()
    {
        mainPlayer.playerScore = 0;
        scoreText.text = mainPlayer.playerScore.ToString();
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
    }
    public void IncreaseGoldScore()
    {
        goldScore++;
        PlayerPrefs.SetInt("TotalCoins", goldScore);
        goldScoreText.text = goldScore.ToString();
    }
}