using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProperties : MonoBehaviour
{
    public string playerName;
    public int playerScore;

    public PlayerProperties(string playerName, int playerScore)
    {
        this.playerName = playerName;
        this.playerScore = playerScore;
    }
    public PlayerProperties()
    {

    }
    public void Clear()
    {
        playerName = string.Empty;
        playerScore = 0;
    }
}