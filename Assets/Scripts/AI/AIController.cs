using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIController : VehicleController
{
    private NavMeshAgent agent;
    private int cPath = 0;
    private int cCheckpoint = 0;
    private NavMeshPath path = new NavMeshPath();

    public GameObject[] checkpoints;

    void Start()
    {
        agent = myVehicle.GetComponent<NavMeshAgent>();
        SetPath(myVehicle.transform.position, checkpoints[cCheckpoint].transform.position);
    }

    void Update()
    {
        if (Vector3.Distance(myVehicle.transform.position, agent.path.corners[0]) <= 5.0f)
        {
            if (Vector3.Distance(myVehicle.transform.position, checkpoints[cCheckpoint].transform.position) <= 10.0f)
            {
                Debug.Log("Changing checkpoints: " + cCheckpoint);
                cCheckpoint++;
                if (cCheckpoint >= checkpoints.Length)
                    cCheckpoint = 0;
                //cPath = 0;
                SetPath(myVehicle.transform.position, checkpoints[cCheckpoint].transform.position);
            }
            else
            {
                Debug.Log("Changing Corner");
                //cPath++;
                SetPath(myVehicle.transform.position, checkpoints[cCheckpoint].transform.position);
            }
        }

        Debug.Log(Quaternion.Lerp(myVehicle.transform.rotation, Quaternion.LookRotation(agent.path.corners[0] - myVehicle.transform.position), 5.0f * Time.deltaTime).eulerAngles);
        if (Quaternion.Lerp(myVehicle.transform.rotation, Quaternion.LookRotation(agent.path.corners[0] - myVehicle.transform.position), 5.0f * Time.deltaTime).eulerAngles.y <= 160.0f)
        {
            Debug.Log("Turning Left");
            SetTurnDirection(-10.0f);
        } else if(Quaternion.Lerp(myVehicle.transform.rotation, Quaternion.LookRotation(agent.path.corners[0] - myVehicle.transform.position), 5.0f * Time.deltaTime).eulerAngles.y >= 100.0f)
        {
            Debug.Log("Turning Right");
            SetTurnDirection(10.0f);
        }
        //SetForwardSpeed(5.0f);
    }

    void SetPath(Vector3 Current, Vector3 Destination)
    {
        agent.SetDestination(Destination);
        //NavMesh.CalculatePath(Current, Destination, NavMesh.AllAreas, path);
    }
}
