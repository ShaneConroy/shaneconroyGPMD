using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class zombieController : MonoBehaviour
{
    public GameObject player;
    public float fov = 90f;
    public float coneLength = 3f;
    NavMeshAgent agent;
    private float timer = .1f;
    private int side = 0;
    GameObject[] studentsArray;


    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;

    }    

    void Update()
    {
        studentsArray = GameObject.FindGameObjectsWithTag("Student");

        checkDetect(player.transform.position);
        studentCheckDetect("Students");

        Vector3 vel = agent.velocity.normalized;
        if (vel.magnitude > 0.1f)
        {
            float rotAngle = Mathf.Atan2(vel.y, vel.x) * Mathf.Rad2Deg;
            rotAngle -= 90f;
            transform.rotation = Quaternion.AngleAxis(rotAngle, Vector3.forward);
        }


    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Student"))
        {
            other.gameObject.tag = "StudentDead";
            gamemanager.students--;
        }
    }

    void studentCheckDetect(string tag)
    {
        foreach (GameObject student in studentsArray)
        {
            checkDetect(student.transform.position);
        }

    }
    void checkDetect(Vector3 targetPos)
    {
        Vector2 coneDir = transform.up;
        Vector2 dir = targetPos - this.transform.position;

        float angle = Vector2.Angle(coneDir, dir);

        if (angle < fov / 2 && dir.magnitude < coneLength)
        {
            agent.SetDestination(targetPos);
        }
        else
        {
            wandering();
        }
    }


    void OnDrawGizmos()
    {
        // Cone of vision for zombie
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, Quaternion.Euler(0, 0, fov / 2) * transform.up * coneLength);
        Gizmos.DrawRay(transform.position, Quaternion.Euler(0, 0, -fov / 2) * transform.up * coneLength);

    }


    void wandering()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            side = Random.Range(0, 2);
            switch (side)
            {
                case 0:
                    agent.SetDestination(new Vector3(Random.Range(-13, -0.5f), Random.Range(-3.6f, 6f), 1));
                    break;
                case 1:
                    agent.SetDestination(new Vector3(Random.Range(-0.5f, 11f), Random.Range(-0.5f, -2.15f), 1));
                    break;
            }
            timer = 10f;
        }
    }
}
