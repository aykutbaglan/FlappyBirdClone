using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NameLoginPanel : MonoBehaviour
{
    public TMP_InputField inputname;
    public bool isNameSaved = false;
    public GameObject nameLoginPanelGo;
    [SerializeField] private TextMeshProUGUI infoText;
    [SerializeField] private ScoreBoardManager scoreBoardManager;
    [SerializeField] private Button saveButton;
    [SerializeField] private PlayerProperties _mainPlayer;
    [SerializeField] private GameManager _gameManager;
    private bool _loginCompleated;

    private void OnEnable()
    {
        saveButton.onClick.AddListener(LoginButton); 
        saveButton.onClick.AddListener(()=>
        {
            if (_loginCompleated)
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
            _loginCompleated = false;
            return;
        }
        _loginCompleated = true;
        scoreBoardManager.SaveScoreBoardData(_mainPlayer.playerScore, inputname.text);
        isNameSaved = true;
        _gameManager.GameOver();
    }
}