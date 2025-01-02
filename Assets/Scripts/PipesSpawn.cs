using UnityEngine;

public class PipesSpawn : MonoBehaviour
{
    [SerializeField] private GameObject pipes;
    [SerializeField] private Transform pipesSpawner;
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float upHeight = 1f;
    [SerializeField] private float downHeight = -5f;
    [SerializeField] private float xPos = 25f;
    [SerializeField] private float spawnRate = 2f;
    [SerializeField] private float despawnTime = 9f;

    private void Start()
    {
        Spawn();
    }
    private void Update()
    {
        transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
    }
    private void Spawn()
    {
        Vector3 pipesSpawner = new Vector3(transform.position.x + xPos,UnityEngine.Random.Range(downHeight,upHeight));
        GameObject newpipe = Instantiate(pipes,pipesSpawner,Quaternion.identity);
        Destroy(newpipe,despawnTime);
        Invoke(nameof(Spawn),spawnRate);
    }
}