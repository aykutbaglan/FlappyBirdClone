using TMPro;
using UnityEngine;

public class ScoreTablePlayer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreNumber;
    [SerializeField] private TextMeshProUGUI playerName;
    [SerializeField] private TextMeshProUGUI score;

    public int SetNumberText
    {
        set
        {
            scoreNumber.text = value.ToString();
        }
    }
    public string SetPlayerName
    {
        set
        {
            playerName.text = value;
        }
    }
    public int SetScoreText
    {
        set
        {
            score.text = value.ToString();
        }
    }    
}