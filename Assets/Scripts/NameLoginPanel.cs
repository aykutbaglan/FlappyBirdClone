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
    public bool isNameSaved = false;
    [SerializeField] private PlayerProperties _mainPlayer;
    [SerializeField] private GameManager _gameManager;
    private bool loginCompleated;

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
        if (string.IsNullOrWhiteSpace(inputname.text.Trim()))
        {
            infoText.text = "Kullanýcý adý boþ olmamalý";
            loginCompleated = false;
            return;
        }
        loginCompleated = true;
        scoreBoardManager.SaveScoreBoardData(_mainPlayer.playerScore, inputname.text);
        isNameSaved = true;
        _gameManager.GameOver();
    }
}