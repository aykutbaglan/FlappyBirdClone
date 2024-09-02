using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class RestartGame : MonoBehaviour
{
    public bool oyunbasladimi = true;

    private void Start()
    {
        if (oyunbasladimi == false)
        {
            Time.timeScale = 0f;
        }
    }
    public void Restart()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        //nextSceneIndex = currentSceneIndex;
        SceneManager.LoadScene(nextSceneIndex);
        //Time.timeScale = 1.0f;
        SceneManager.LoadScene(1);
    }
    public void GameOverRestart()
    {
        SceneManager.LoadScene(1);
    }
}
