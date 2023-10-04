using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followEnemy : MonoBehaviour
{
    public GameObject follower;
    public GameObject player;
    public Vector2 direction;
    private float speed = 2;
 

    private void Start()
    {
        player = GameObject.Find("playerSprite");
    }

    private void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
    }

    void Update()
    {
        
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Bullet"))
        {
            GameObject.Destroy(this.gameObject);
            Destroy(collision.gameObject);
            HUDController.deaths++;
        }
    }


}
