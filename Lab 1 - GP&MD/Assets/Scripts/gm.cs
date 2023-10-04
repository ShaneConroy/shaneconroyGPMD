using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gm : MonoBehaviour
{
    public GameObject follower;
    private int followerAmount_waveTwo = 0;

    private int enemyTotal = 34;//34, 
    private int enemyRemain;

    public GameObject vert;
    private int vertAmount_waveTwo = 0;

    bool waveOneOver = false;
    bool waveThreeReady = false;

    private int followerAmount_waveThree;
    private int vertAmount_waveThree;
    void Update()
    {
        

        enemyRemain = GameObject.FindGameObjectsWithTag("Enemy").Length; // Find al enemies

        if (enemyRemain <= 0) // If no enemy remain
        {
            waveOneOver = true; // start wave two

        }

        if(waveOneOver) 
        {
            if (followerAmount_waveTwo <= 8)
            {
                spawn_followers_waveTwo();
            }

            if (vertAmount_waveTwo <= 20)
            {
                spawn_vert_waveTwo();
            }
        }

        // If all enemies in wave two are spawned
        if(vertAmount_waveTwo >= 20 && followerAmount_waveTwo >= 8)
        {
            waveThreeReady = true;
        }

        // If all enemies from wave two are dead
        if(waveThreeReady && enemyRemain <= 0) 
        {
            // Spawn wave three
            if(followerAmount_waveThree <= 12)
            {
                spawn_followers_waveThree();
            }
            if(vertAmount_waveThree >= 10)
            {
                spawn_vert_waveThree();
            }

        }

    }

    void spawn_followers_waveTwo()
    {
        var position = new Vector2(Random.Range(-15f, 15f), Random.Range(-25f, -5f));
        Instantiate(follower, position, Quaternion.identity);
        followerAmount_waveTwo++;

    }
    void spawn_vert_waveTwo()
    {
        var position = new Vector2(Random.Range(-15f, 15f), 15f);
        Instantiate(vert, position, Quaternion.identity);
        vertAmount_waveTwo++;
    }

    void spawn_followers_waveThree()
    {
        var position = new Vector2(Random.Range(-15f, 15f), Random.Range(-25f, -5f));
        Instantiate(follower, position, Quaternion.identity);
        followerAmount_waveThree++;
    }

    void spawn_vert_waveThree()
    {
        var position = new Vector2(Random.Range(-15f, 15f), 15f);
        Instantiate(vert, position, Quaternion.identity);
        vertAmount_waveThree++;
    }
}
