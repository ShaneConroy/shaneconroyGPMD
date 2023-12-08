using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class studentController : MonoBehaviour
{
    NavMeshAgent agent;
    private float timer = .1f;
    private int roomNum = 0;

    public static bool alive = true;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    void Update()
    {
        

        if(this.tag == "Student")
        {
            this.GetComponent<SpriteRenderer>().color = new Color(0, 1, 0);
            goingToClass();
        }
        else if(this.tag == "StudentDead")
        {
            this.GetComponent<SpriteRenderer>().color = new Color(1, 0, 0);

            this.agent.speed = 0;
            this.GetComponent<Collider2D>().enabled = false;
            this.GetComponent<NavMeshAgent>().enabled = false;
        }

        if( 1 == 2)
        {
            //fleeing();
        }
    }

    void goingToClass()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            roomNum = Random.Range(0, 7);
            switch (roomNum)
            {
                case 0: // R1
                    agent.SetDestination(new Vector3(Random.Range(-9.51f, 2.07f), Random.Range(-6.03f, 0.98f), 1));
                    break;
                case 1: // R2
                    agent.SetDestination(new Vector3(Random.Range(-21.5f, -15.5f), Random.Range(-2.84f, 4.36f), 1));
                    break;
                case 2: // R3
                    agent.SetDestination(new Vector3(Random.Range(-32.43f, -26.4f), Random.Range(-2.8f, 8.18f), 1));
                    break;
                case 3: // R4
                    agent.SetDestination(new Vector3(Random.Range(15.15f, 28.1f), Random.Range(3.82f, 15.66f), 1));
                    break;
                case 4: // Outside
                    agent.SetDestination(new Vector3(Random.Range(-19.38f, 0f), Random.Range(6.13f, 14.9f), 1));
                    break;
                case 5: // Hallway
                    agent.SetDestination(new Vector3(Random.Range(7.07f, 13.34f), Random.Range(0.46f, 15.54f), 1));
                    break;
                case 6: // Gym
                    agent.SetDestination(new Vector3(Random.Range(15.29f, 28.04f), Random.Range(-5.79f, 2.41f), 1));
                    break;
            }
            timer = 15f;
        }
    }

    //void fleeing()
    //{

    //}
}
