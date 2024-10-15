using Game.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreButton : MonoBehaviour
{
    [SerializeField] private ScoreCanvas _scoreCanvas;
    [SerializeField] private Button _scoreButton;
    [SerializeField] private StartMenu _startMenu;
    [SerializeField] private GameObject _closeScoreButton;

    private void Start()
    {
        _closeScoreButton.SetActive(false);
    }
    private void OnEnable()
    {
        _scoreButton.onClick.AddListener(OpenScoreMenu);
    }
    private void OnDisable()
    {
        _scoreButton.onClick.RemoveListener(OpenScoreMenu);
    }
    public void OpenScoreMenu()
    {
        _scoreCanvas.OpenMenu();
        _startMenu.CloseMenu();
        _closeScoreButton.SetActive(true);
    }
    public void CloseScoreMenu()
    {
        _scoreCanvas.CloseMenu();
        _closeScoreButton.SetActive(false);
    }
}
