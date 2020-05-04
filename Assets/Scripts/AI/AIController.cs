using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class AIController : MonoBehaviour
{
    public GameObject[] checkpoints;

    void Start()
    {
        
    }

    void Update()
    {
        gameObject.SendMessage("Rotate", 1.0f);
    }

    private void FixedUpdate()
    {
        gameObject.SendMessage("Forward", 1.0f);
    }
}
