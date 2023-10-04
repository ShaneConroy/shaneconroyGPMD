using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed = 10f;
    public float lifetime = 2f;

    private void Start()
    {
        // Destroy the bullet after 'lifetime' seconds
        Destroy(gameObject, lifetime);
    }

    private void Update()
    {
        // Move the bullet upward
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }
}
