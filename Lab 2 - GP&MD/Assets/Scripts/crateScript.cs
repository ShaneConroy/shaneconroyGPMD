using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crateScript : MonoBehaviour
{
    public GameObject crate;
    public static float respawnTimer = 8f;
    public GameObject spawn1;
    public GameObject spawn2;
    public Rigidbody2D crateRB;
    public static int side;

    private int speed = 4;

    private void Start()
    {
        crate.transform.position = spawn1.transform.position;

        // Difficulty settings
        if (gameManager.difficulty == 1)
        {
            speed = 4;
            respawnTimer = 8f;
        }
        if (gameManager.difficulty == 2)
        {
            speed = 7;
            respawnTimer = 6f;
        }
        if (gameManager.difficulty == 3)
        {
            speed = 10;
            respawnTimer = 4f;
        }

    }
    void Update()
    {

        // Constantly decrease timer
        respawnTimer -= Time.deltaTime;

        // When timer runs out pick a side then respawn
        if(respawnTimer < 0 )
        {
            side = Random.Range(1, 3);
            if(side == 2 )
            {
                crate.transform.position = spawn1.transform.position;
                crateRB.velocity = new Vector2(speed, 0);
            }
            if (side == 1 )
            {
                crate.transform.position = spawn2.transform.position;
                crateRB.velocity = new Vector2(-speed, 0);
            }

            // Always reset timer
            respawnTimer = 8f;
        }
    }

}
