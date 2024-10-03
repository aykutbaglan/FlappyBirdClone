using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ScoreBoardManager : MonoBehaviour
{
    [SerializeField] private ScoreTablePlayer[] scorePlayers;
    public GameObject nameLoginPanel;

    private void Start()
    {
        LoadScoreBoardData();
    }
    public void LoadScoreBoardData()
    {
        for (int i = 0; i < scorePlayers.Length; i++)
        {
            scorePlayers[i].SetNumberText = (i + 1);
            scorePlayers[i].SetPlayerName = PlayerPrefs.GetString("ScoreBoardName" + i);
            scorePlayers[i].SetScoreText = PlayerPrefs.GetInt("ScoreBoardScore" +i);
            Debug.Log(PlayerPrefs.GetString("ScoreBoardName" + i));

        }
        Debug.Log("Loadddddd");

    }
    public void SaveScoreBoardData(int score , string name) //�ld���m�z zaman scoreboard a girmeye hakk�m�z varm� diye sorulacak fonksiyon un benzeri
    {
        int minScore = PlayerPrefs.GetInt("ScoreBoardScore9");
        if (score > minScore)
        {
            int index = 9;
            nameLoginPanel.SetActive(true);
            if (PlayerPrefs.GetInt("ScoreBoardScore0") <= score)
            {
                index = 0;
            }
            else
            {
                for (int i = scorePlayers.Length - 1; i > 0; i--)
                {
                    if (PlayerPrefs.GetInt("ScoreBoardScore" + i) < score && PlayerPrefs.GetInt("ScoreBoardScore" + (i - 1)) >= score)
                    {
                        index = i; 
                        break;
                    }
                }
            }

            ShiftScores(index);
            SaveCurrentScore(score,name,index);
            Debug.Log("SaveScoreBoardData:" + name +" " + score +" " + index);
        }else//Score u kaydedilmeyecek
        {

        }
        LoadScoreBoardData();
    }
    public void ShowNameLoginPanel()
    {
        //nameLoginPanel.SetActive(true);
        //if (scorePlayers != null)
        //{
        //    nameLoginPanel.SetActive(true);
        //}
        //else
        //{
        //    nameLoginPanel.SetActive(false);
        //}
    }
public void ShiftScores(int index)
    {
        for (int i = scorePlayers.Length - 1; i > index; i--)
        {
            int tempScore = PlayerPrefs.GetInt("ScoreBoardScore" + (i - 1));
            string tempName = PlayerPrefs.GetString("ScoreBoardName" + (i - 1));
            PlayerPrefs.SetInt("ScoreBoardScore" + i,tempScore);
            PlayerPrefs.SetString("ScoreBoardName"+i,tempName);
        }
    }
    public void SaveCurrentScore(int score,string name,int index)
    {
        PlayerPrefs.SetInt("ScoreBoardScore"+index,score);
        PlayerPrefs.SetString("ScoreBoardName" + index, name);
    }
}
