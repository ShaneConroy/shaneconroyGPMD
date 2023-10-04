using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed = 2f;
    private Transform player;

    private void Start()
    {
        player = GameObject.Find("playerSprite").transform;
    }

    private void Update()
    {
        // Move towards the player
        Vector2 direction = (player.position - transform.position).normalized;
        GetComponent<Rigidbody2D>().velocity = direction * moveSpeed;
    }
}

