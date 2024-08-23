using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipesSpawn : MonoBehaviour
{
    public GameObject pipes;
    public Transform pipesSpawner;
    public float spawnspeed = 10f;
    public float upHeight = 1f;
    public float downHeight = -5f;
    public float xPos = 25f;

    private void Start()
    {
        Invoke(nameof(Spawn), 1f);
    }
    private void Update()
    {
        transform.Translate(Vector3.right * spawnspeed * Time.deltaTime);
    }
    public void Spawn()
    {
        Vector3 pipesSpawner = new Vector3(transform.position.x + xPos,UnityEngine.Random.Range(downHeight,upHeight));
        Instantiate(pipes,pipesSpawner,Quaternion.identity);
        Invoke(nameof(Spawn),2f);
    }
}