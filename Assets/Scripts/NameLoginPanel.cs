using Game.UI;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NameLoginPanel : MonoBehaviour
{
    public bool isNameSaved = false;
    public TMP_InputField inputname;
    public GameObject nameLoginPanelGo;
    [SerializeField] private TextMeshProUGUI infoText;
    [SerializeField] private ScoreBoardManager scoreBoardManager;
    [SerializeField] private Button saveButton;
    [SerializeField] private PlayerProperties _mainPlayer;
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private ScoreButton _scoreButton;
    [SerializeField] private ShopButton _shopButton;
    [SerializeField] private EndGameMenu _endGameMenu;
    [SerializeField] private CanvasMainMenu _canvasMainMenu;
    private bool _loginCompleated;

    private void OnEnable()
    {
        saveButton.onClick.AddListener(LoginButton);
        saveButton.onClick.AddListener(() =>
        {
            if (_loginCompleated)
            {
                gameObject.SetActive(false);
            }
        });
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
    public void NameLoginPanelControl()
    {
        if (nameLoginPanelGo.activeSelf == true)
        {
            _endGameMenu.restartButtonGo.SetActive(false);
            _scoreButton._scoreButtonGo.SetActive(false);
            _shopButton.shopButtonGo.SetActive(false);
            _canvasMainMenu.CloseMenu();
        }
        else
        {
            _endGameMenu.restartButtonGo.SetActive(true);
            _scoreButton._scoreButtonGo.SetActive(true);
            _shopButton.shopButtonGo.SetActive(true);
            _canvasMainMenu.OpenMenu();
        }
    }
}