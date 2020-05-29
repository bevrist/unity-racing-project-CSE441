﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIController : VehicleController
{
    private NavMeshAgent agent;
    private int cPath = 0;
    private int cCheckpoint = 0;
    private NavMeshPath path = new NavMeshPath();

<<<<<<< Updated upstream
=======
    public float currentSpeed;
    public float maxSpeed = 5.0f;
    public float turnSpeed = 5.0f;
>>>>>>> Stashed changes
    public GameObject[] checkpoints;

    void Start()
    {
        agent = myVehicle.GetComponent<NavMeshAgent>();
        SetPath(myVehicle.transform.position, checkpoints[cCheckpoint].transform.position);
    }

    void Update()
    {
        if (Vector3.Distance(myVehicle.transform.position, checkpoints[cCheckpoint].transform.position) <= 3.0f)
        {
            cCheckpoint++;
            if (cCheckpoint >= checkpoints.Length)
                cCheckpoint = 0;
            //cPath = 0;
            SetPath(myVehicle.transform.position, checkpoints[cCheckpoint].transform.position);
        }
        else
        {
            cPath++;
            //SetPath(myVehicle.transform.position, checkpoints[cCheckpoint].transform.position);
        }

<<<<<<< Updated upstream
        /*Debug.Log("Location: " + agent.path.corners[0]);
        Debug.Log(Quaternion.Lerp(myVehicle.transform.rotation, Quaternion.LookRotation(agent.path.corners[0] - myVehicle.transform.position), 5.0f * Time.deltaTime).eulerAngles);
        if (Quaternion.Lerp(myVehicle.transform.rotation, Quaternion.LookRotation(agent.path.corners[0] - myVehicle.transform.position), 5.0f * Time.deltaTime).eulerAngles.y <= 160.0f)
        {
            Debug.Log("Turning Left");
            SetTurnDirection(-10.0f);
        } else if(Quaternion.Lerp(myVehicle.transform.rotation, Quaternion.LookRotation(agent.path.corners[0] - myVehicle.transform.position), 5.0f * Time.deltaTime).eulerAngles.y >= 100.0f)
        {
            Debug.Log("Turning Right");
            SetTurnDirection(10.0f);
        }*/
        SetForwardSpeed(5.0f);
=======
        if (Physics.Raycast(myVehicle.transform.position, Vector3.down, out RaycastHit hit, 2))
        {
            if (hit.collider.gameObject.tag == "Slow")
            {
                currentSpeed = maxSpeed / 2;
            }
            else
            {
                currentSpeed = maxSpeed;
            }
        }

        Quaternion rotation = Quaternion.Lerp(myVehicle.transform.rotation, Quaternion.LookRotation(agent.path.corners[1] - myVehicle.transform.position, myVehicle.transform.up), Time.deltaTime * turnSpeed);
        myVehicle.transform.rotation = rotation;
        SetForwardSpeed(currentSpeed);
>>>>>>> Stashed changes
    }

    void SetPath(Vector3 Current, Vector3 Destination)
    {
        agent.SetDestination(Destination);
    }
}