using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinScript : MonoBehaviour
{
    private float moveTimer = 3f;
    public GameObject coin;

    private void Start()
    {
        coin.transform.position = new Vector3(Random.Range(-9, 10), Random.Range(-2, 1), 0);
    }
    void Update()
    {
        moveTimer -= Time.deltaTime;
        if(moveTimer < 0)
        {
            coin.transform.position = new Vector3(Random.Range(-9, 10), Random.Range(-2, 1), 0);
            moveTimer = 3f;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision != null)
        {
            if(collision.tag == "Player")
            {
                coin.transform.position = new Vector3(-100, -100, 0);
                canvasScript.coinAmount++;
            }
        }
    }

}
