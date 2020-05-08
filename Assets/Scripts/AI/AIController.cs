using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class AIController : MonoBehaviour
{
    private NavMeshAgent agent;
    public GameObject[] checkpoints;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        //gameObject.SendMessage("Rotate", 1.0f);
        agent.SetDestination(checkpoints[0].transform.position);
        NavMeshPath path = new NavMeshPath();
        NavMesh.CalculatePath(transform.position, checkpoints[0].transform.position, NavMesh.AllAreas, path);
        Debug.Log(path.corners[0]);
    }

    private void FixedUpdate()
    {
        //gameObject.SendMessage("Forward", 1.0f);
    }
}
