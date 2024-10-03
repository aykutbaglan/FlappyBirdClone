using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ScoreRanking : MonoBehaviour
{
    public PlayerProperties[] playerProperties;
    public ScoreTablePlayer[] players = new ScoreTablePlayer[10];
    [SerializeField] private List<PlayerProperties> sortingPlayers = new List<PlayerProperties>();
    public GameObject scoreRankingPanel;
    public GameObject shopPanel;
    public int currentScore = 0;
    public PlayerProperties mainPlayer;
    public Button saveScoreButtonTest;
    public GameObject restartButton;
    public GameObject startButton;
    private void Start()
    {
        if (playerProperties.Length != players.Length)
        {
            return;
        }
        WriteAllDataBoard();
        PlayerSort();
        RefreshBoard();
    }

    /// <summary>
    /// CheckNullPlayerProperties() = null kontrolü yapýlýr
    /// CheckNearestScorePlayerProperties() = dizide ki en küçük elemaný döndürür
    /// CheckPlayerProperties()  = player a null kontrolü yapýlýr null ise player a en küçük deðer atanýr hala null ise player döndürülür.
    /// </summary>
    /// <returns>En uygun Olan player propetiesi geri dönderir!</returns>
    private PlayerProperties CheckPlayerProperties()
    {
        PlayerProperties player = CheckNullPlayerProperties();
        if (player == null)
        {
            player = CheckNearestScorePlayerProperties();
            if (player == null)
            {
                Debug.LogError("null");
            }
            return player;  
        }
        return player;
    }
    /*
     * 
     * 
     * 
     * 
     * 
     */
    /// <summary>
    /// skor tablosunda ki verileri güncelliyor.
    /// </summary>
    private PlayerProperties CheckNullPlayerProperties()
    {
        for (int i = 0; i < playerProperties.Length; i++)
        {
            if (playerProperties[i] == null)
            {
                return playerProperties[i];
            }
        }
        return null;
    }

    private PlayerProperties CheckNearestScorePlayerProperties()
    {
        int minNumber;
        PlayerProperties minScorePlayer = null;
        minNumber = int.MaxValue;
        for (int i = 0; i < playerProperties.Length; i++)
        {
            if (playerProperties[i].playerScore < minNumber)
            {
                minNumber = playerProperties[i].playerScore;
                minScorePlayer = playerProperties[i];
            }
        }
        return minScorePlayer;
    }
   
    private void SaveBoard()
    {
        PlayerPrefs.SetString("playerName", CheckPlayerProperties().playerName);
        PlayerPrefs.SetInt("playerScore", CheckPlayerProperties().playerScore);




        for (int i = 0; i < playerProperties.Length; i++)
        {

        }
    }
    private void WriteAllDataBoard()
    {
        PlayerProperties playerproperties = CheckPlayerProperties();
        playerproperties.playerName = PlayerPrefs.GetString("playerName");
        playerproperties.playerScore = PlayerPrefs.GetInt("playerScore");
        
    }
    private void RefreshBoard()
    {
        for (int i = 0; i < playerProperties.Length; i++)
        {
            players[i].SetPlayerName = playerProperties[i].playerName;
            players[i].SetScoreText = playerProperties[i].playerScore;
            players[i].SetNumberText = i + 1;
        }
        SaveBoard();
    }
    public void ClearAllText()
    {
        for(int i = 0;i < players.Length;i++)
        {
            players[i].SetPlayerName = "";
            players[i].SetScoreText = 0;
        }
    }

    public void PlayerSort()
    {
        int currentMinScore;
        PlayerProperties currentMinScorePlayer;

        for (int i = 0; i < playerProperties.Length; i++)
        {
            currentMinScore = int.MaxValue;
            currentMinScorePlayer = null;
            for (int a = 0; a < playerProperties.Length; a++)
            {
                if (playerProperties[a].playerName == "" || sortingPlayers.Contains(playerProperties[a]))
                {
                    continue;
                }
                if (playerProperties[a].playerScore <= currentMinScore)
                {
                    currentMinScore = playerProperties[a].playerScore;
                    currentMinScorePlayer = playerProperties[a];
                }
            }
            if (currentMinScorePlayer != null)
            {
                sortingPlayers.Add(currentMinScorePlayer);
                Debug.Log($"Min Score Player {currentMinScorePlayer.playerName} \n {currentMinScore}");
            }
            ClearAllText();
            SortingApply();
            int index = 0;
            foreach (var player in sortingPlayers)
            {
                Debug.Log($"{index}. player => {player.playerName}");
                index++;
            }
        }
    }
    public void SortingApply()
    {
        int index = 0;
        for (int i =  sortingPlayers.Count -1; i >= 0; i--)
        {
            players[index].SetPlayerName = sortingPlayers[i].playerName;
            players[index].SetScoreText = sortingPlayers[i].playerScore;
            index++;
        }
    }
    public void OpenRankPanel()
    {
        scoreRankingPanel.SetActive(true);
        if (shopPanel.activeSelf)
        {
            startButton.SetActive(false);
            shopPanel.SetActive(false);
            restartButton.SetActive(false);
        }
        if (scoreRankingPanel.activeSelf)
        {
            WriteAllDataBoard();
            RefreshBoard();
            PlayerSort();
            restartButton.SetActive(false);
            startButton.SetActive(false);
        }
        else
        {
            restartButton.SetActive(true);
        }
    }
    public void CloseRankingPanel()
    {
        scoreRankingPanel.SetActive(false);
    }
    public void PanelOrganization()
    {
        if (scoreRankingPanel.activeSelf)
        {
            shopPanel.SetActive(false);
        }
    }
}