using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class birdController : MonoBehaviour
{
    public float speed = 5f;
    public float jumpingForce;
    public Transform bird;
    private Rigidbody2D rb;

    // Rotasyon için deðiþkenler
    private float targetRotation;
    public float smoothRotationSpeed = 12f; // Yumuþak geçiþ için hýz

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Kuþun saða doðru sürekli hareket etmesi
        bird.position += Vector3.right * speed * Time.deltaTime;

        // Mouse týklamasýyla kuþun zýplamasý ve z rotasyonunu ayarlama
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            rb.velocity = Vector2.up * -jumpingForce;
            targetRotation = -20.0f; // Aþaðý doðru bakýþ rotasyonu
        }

        // Kuþ yukarý doðru çýkarken z rotasyonunu +20 yapmak
        if (rb.velocity.y > 0)
        {
            targetRotation = 20.0f; // Yukarý doðru bakýþ rotasyonu
        }
        // Kuþ aþaðý düþerken z rotasyonunu -20 yapmak
        else if (rb.velocity.y < 0)
        {
            targetRotation = -20.0f; // Aþaðý doðru bakýþ rotasyonu
        }

        // Mevcut rotasyonu hedef rotasyona doðru yumuþak bir þekilde geçiþ yap
        float currentZRotation = Mathf.LerpAngle(transform.eulerAngles.z, targetRotation, smoothRotationSpeed * Time.deltaTime);
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, currentZRotation);
    }
}
