using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdCollision : MonoBehaviour
{
    public GameObject bird;
    public GameObject gameovermenu;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag =="obstacle")
        {
            GameOver();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "coin")
        {
            Destroy(other.gameObject);
        }
    }
    public void GameOver()
    {
        Time.timeScale = 0f;
        gameovermenu.SetActive(true);
    }
}
