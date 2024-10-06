using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NameLoginPanel : MonoBehaviour
{
    public Button saveButton;
    public TMP_InputField inputname;
    public TextMeshProUGUI infoText;
    public ScoreBoardManager scoreBoardManager;
    private bool loginCompleated;
    [SerializeField] private PlayerProperties _mainPlayer;

    private void OnEnable()
    {
        saveButton.onClick.AddListener(LoginButton); 
        saveButton.onClick.AddListener(()=>
        {
            if (loginCompleated)
            {
                gameObject.SetActive(false);
            }
        } );
    }
    private void OnDisable()
    {
        saveButton.onClick.RemoveListener(LoginButton);
    }
    public void LoginButton()
    {
        if (inputname.text == "")
        {
            infoText.text = "Kullanýcý adý boþ olmamalý";
            loginCompleated = false;
            return;
        }
        loginCompleated = true;
        scoreBoardManager.SaveScoreBoardData(_mainPlayer.playerScore, inputname.text);
    }
}