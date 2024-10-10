using Game.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdCollision : MonoBehaviour
{
    public GameObject bird;
    public GameObject gameovermenu;
    public GameManager gameManager;
    [SerializeField] private EndGameMenu endGameMenu;

    private void Awake()
    {
        if (gameManager == null)
        {
            gameManager = FindObjectOfType<GameManager>();
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag =="obstacle")
        {
            gameManager.GameOver();
            endGameMenu.OpenMenu();
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "score")
        {
            FindObjectOfType<ScoreManager>().IncreaseScore();
        }
        if (other.gameObject.tag == "coin")
        {
            FindObjectOfType<ScoreManager>().IncreaseGoldScore();
            Destroy(other.gameObject);
        }
    }
}