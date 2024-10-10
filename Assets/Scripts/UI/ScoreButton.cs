using Game.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreButton : MonoBehaviour
{
    [SerializeField] private ScoreCanvas _scoreCanvas;

    public void OpenScoreMenu()
    {
        _scoreCanvas.OpenMenu();
    }
    public void CloseScoreMenu()
    {
        _scoreCanvas.CloseMenu();
    }
}
