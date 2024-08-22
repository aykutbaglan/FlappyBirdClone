using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinDestroy : MonoBehaviour
{
    public GameObject coin;
    private void Start()
    {
        Destroy(coin, 7f);
    }
}
