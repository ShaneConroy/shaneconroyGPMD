using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyController : MonoBehaviour
{
    public float speed = 1;
    public Vector2 enemySpawn;
    public GameObject enemy;

    

    void Start()
    {
        enemySpawn.y = -2;
        enemySpawn.x = 0;
    }

    void Update()
    {
        Vector2 minimumPosition = Camera.main.ScreenToWorldPoint(Vector2.zero);

        transform.Translate(Vector2.down * speed * Time.deltaTime);

        if (transform.position.y < minimumPosition.y)
        {
            transform.position = new Vector3(transform.position.x, 5.5f, transform.position.z);

        }
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
