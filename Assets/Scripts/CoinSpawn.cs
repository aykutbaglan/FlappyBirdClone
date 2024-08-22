using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawn : MonoBehaviour
{
    public GameObject coin;

    private void Start()
    {
        Coin();
    }

    public void Coin()
    {
        if (UnityEngine.Random.Range(0, 1) == 0)
        {
            coin.SetActive(true);
        }
    }

}
