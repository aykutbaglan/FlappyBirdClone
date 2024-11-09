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
        if (UnityEngine.Random.Range(0, 5) == 0)
        {
            coin.SetActive(true);
        }
    }
}
