using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class pathfindingScript : MonoBehaviour
{
    [SerializeField] Transform destination;

    public static NavMeshAgent plyrAgent;

    private void Start()
    {
        plyrAgent = GetComponent<NavMeshAgent>();
        plyrAgent.updateRotation = false;
        plyrAgent.updateUpAxis = false;
    }

    private void Update()
    {
        plyrAgent.SetDestination(destination.position);
    }
}
