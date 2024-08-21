using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class birdController : MonoBehaviour
{
    public float speed = 5f;
    public float jumpingForce;
    public Transform bird;
    private Rigidbody2D rb;
    Vector3 velocity;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        bird.position += Vector3.right * speed * Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            rb.velocity = Vector2.up * -jumpingForce;
        }
    }
}