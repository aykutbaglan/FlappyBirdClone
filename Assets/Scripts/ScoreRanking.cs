using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreRanking : MonoBehaviour
{
    public GameObject rankingPanel;
    public GameObject shopPanel;
    private Button closeButton;

    public void ScoreRank()
    {
        rankingPanel.SetActive(true);
        if (shopPanel.activeSelf)
        {
            shopPanel.SetActive(false);
        }
    }
    public void CloseButton()
    {
        rankingPanel.SetActive(false);
    }
    public void PanelOrganization()
    {
        
        if (rankingPanel.activeSelf)
        {
            shopPanel.SetActive(false);
        }
    }
}
