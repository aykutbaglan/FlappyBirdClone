using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class birdController : MonoBehaviour
{
    public float speed = 5f;
    public float jumpingForce;
    public Transform bird;
    private Rigidbody2D rb;

    // Rotasyon i�in de�i�kenler
    private float targetRotation;
    public float smoothRotationSpeed = 12f; // Yumu�ak ge�i� i�in h�z

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Ku�un sa�a do�ru s�rekli hareket etmesi
        bird.position += Vector3.right * speed * Time.deltaTime;

        // Mouse t�klamas�yla ku�un z�plamas� ve z rotasyonunu ayarlama
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            rb.velocity = Vector2.up * -jumpingForce;
            targetRotation = -20.0f; // A�a�� do�ru bak�� rotasyonu
        }

        // Ku� yukar� do�ru ��karken z rotasyonunu +20 yapmak
        if (rb.velocity.y > 0)
        {
            targetRotation = 20.0f; // Yukar� do�ru bak�� rotasyonu
        }
        // Ku� a�a�� d��erken z rotasyonunu -20 yapmak
        else if (rb.velocity.y < 0)
        {
            targetRotation = -20.0f; // A�a�� do�ru bak�� rotasyonu
        }

        // Mevcut rotasyonu hedef rotasyona do�ru yumu�ak bir �ekilde ge�i� yap
        float currentZRotation = Mathf.LerpAngle(transform.eulerAngles.z, targetRotation, smoothRotationSpeed * Time.deltaTime);
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, currentZRotation);
    }
}
