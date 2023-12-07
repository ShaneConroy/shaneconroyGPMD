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
                case 0:
                    agent.SetDestination(new Vector3(Random.Range(-3.7f, 0.75f), Random.Range(-2.3f, 0.2f), 1));
                    break;
                case 1:
                    agent.SetDestination(new Vector3(Random.Range(-8.5f, -6.4f), Random.Range(-1f, 1.7f), 1));
                    break;
                case 2:
                    agent.SetDestination(new Vector3(Random.Range(-13f, -11f), Random.Range(3f, -0.8f), 1));
                    break;
                case 3:
                    agent.SetDestination(new Vector3(Random.Range(-7.5f, -2f), Random.Range(5f, 3.2f), 1));
                    break;
                case 4:
                    agent.SetDestination(new Vector3(Random.Range(3.1f, 5.3f), Random.Range(1.3f, 6.15f), 1));
                    break;
                case 5:
                    agent.SetDestination(new Vector3(Random.Range(6.5f, 11.2f), Random.Range(1.8f, 6.1f), 1));
                    break;
                case 6:
                    agent.SetDestination(new Vector3(Random.Range(6.5f, 11f), Random.Range(-2.2f, 0.7f), 1));
                    break;
            }
            timer = 15f;
        }
    }

    //void fleeing()
    //{

    //}
}
