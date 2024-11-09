using UnityEngine;

public class PipesSpawn : MonoBehaviour
{
    [SerializeField] private GameObject pipes;
    [SerializeField] private Transform pipesSpawner;
    [SerializeField] private float spawnspeed = 10f;
    [SerializeField] private float upHeight = 1f;
    [SerializeField] private float downHeight = -5f;
    [SerializeField] private float xPos = 25f;

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
        GameObject newpipe = Instantiate(pipes,pipesSpawner,Quaternion.identity);
        Destroy(newpipe,7f);
        Invoke(nameof(Spawn),2f);
    }
}