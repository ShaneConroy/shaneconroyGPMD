using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public GameObject bulletPrefab;
    public Transform firePoint;

    private void Update()
    {
        // Player movement
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(horizontalInput, verticalInput);
        GetComponent<Rigidbody2D>().velocity = movement * moveSpeed;

        // Shooting
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
        
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Player collided with an enemy, trigger game over
            FindObjectOfType<GameController>().GameOver();
            Destroy(gameObject);
        }
    }

}
