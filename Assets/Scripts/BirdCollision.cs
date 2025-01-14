using UnityEngine;

public class BirdCollision : MonoBehaviour
{
    public GameManager gameManager;

    [SerializeField] private AudioSource pointSfx;
    [SerializeField] private AudioSource scoreSfx;
    [SerializeField] private AudioSource dieSfx;
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
            EndingState.GameFail = true;
            gameManager.GameOver();
            dieSfx.Play();
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "score")
        {
            FindObjectOfType<ScoreManager>().IncreaseScore();
            scoreSfx.Play();
        }
        if (other.gameObject.tag == "coin")
        {
            FindObjectOfType<ScoreManager>().IncreaseGoldScore();
            Destroy(other.gameObject);
            pointSfx.Play();
        }
    }
}