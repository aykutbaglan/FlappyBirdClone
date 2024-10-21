using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{
    public bool startgame;
    
    private void Start()
    {
        GameManager.GameResume();
    }
    public void Restart()
    {
        SceneManager.LoadScene(1);
        
    }
}


