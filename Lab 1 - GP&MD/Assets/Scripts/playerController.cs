using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using static UnityEditor.Timeline.TimelinePlaybackControls;
using Unity.VisualScripting;

public class playerController : MonoBehaviour
{
    private float speed = 5.0f;
    public GameObject bullet;
    public GameObject player;
    public Transform firepoint;
    public List<Transform> firepoints;
    private float cooldown = 1.0f; // Timer inbetween shots
    private float shotgunCooldown = 1.0f;
    private float autogunCooldown = 0.1f;

    private bool shotgun = true;
    private bool autogun = false;

    void Start()
    {
        player = GameObject.Find("playerSprite");
    }

    void Update()
    {

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(horizontalInput, verticalInput);
        GetComponent<Rigidbody2D>().velocity = movement * speed;


        cooldown -= Time.deltaTime; // Counts down

        // Swapping weapons
        if(Input.GetMouseButtonUp(0))
        {
            if(shotgun)
            {
                shotgun = false;
                autogun = true;
            }
            else if(!shotgun) 
            {
                shotgun = true;
                autogun = false;
            }
            
        }

        if (shotgun) // Shotgun code
        {
           
            if (cooldown <= 0.0f)
            {
                for(int i = 0; i < 4; i++)
                {
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        Instantiate(bullet, firepoints[0].position, Quaternion.identity);
                        Instantiate(bullet, firepoints[1].position, Quaternion.identity);
                        Instantiate(bullet, firepoints[2].position, Quaternion.identity);
                        Instantiate(bullet, firepoints[3].position, Quaternion.identity);
                        cooldown = shotgunCooldown;
                    }
                }
               

            }
        }
        if(autogun)
        {
            
            if (cooldown <= 0.0f)
            {
                if (Input.GetKey(KeyCode.Space))
                {
                    Instantiate(bullet, firepoint.position, Quaternion.identity);
                    cooldown = autogunCooldown;
                   
                }
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Player x Enemy
        if(collision.gameObject.CompareTag("Enemy"))
        {
            GameObject.Destroy(player.gameObject);
            winlose.playerDead = true;
            Time.timeScale = 0f;
        }
    }
}
