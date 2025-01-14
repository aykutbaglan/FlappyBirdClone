using UnityEngine;

public class birdController : MonoBehaviour
{
    public float speed = 5f;
    public float jumpingForce;
    public Transform bird;
    public float smoothRotationSpeed = 12f;
    [SerializeField] private AudioSource flySfx;
    private Rigidbody2D _rb;
    private float _targetRotation;
    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        bird.position += Vector3.right * speed * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            _rb.velocity = Vector2.up * -jumpingForce;
            if (Time.timeScale == 1)
            {
            flySfx.Play();
            }
            _targetRotation = -20.0f;
        }
        if (_rb.velocity.y > 0)
        {
            _targetRotation = 20.0f;
        }
        else if (_rb.velocity.y < 0)
        {
            _targetRotation = -20.0f;
        }
        float currentZRotation = Mathf.LerpAngle(transform.eulerAngles.z, _targetRotation, smoothRotationSpeed * Time.deltaTime);
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, currentZRotation);
    }
}