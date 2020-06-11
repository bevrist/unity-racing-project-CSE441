using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriveStraightTowardCheckpointAi : VehicleController
{
    private CheckpointSystemVehicle checkpointSystem;

    void Start()
    {
        //verify that checkpoints.list is not empty
        if (Checkpoints.list.Length == 0) { Debug.LogError("No Checkpoints found in level", gameObject); }

        //Get reference to CheckpointSystemVehicle
        checkpointSystem = myVehicle.GetComponent<CheckpointSystemVehicle>();
        //error if checkpointSystem not found
        if (checkpointSystem == null) { Debug.LogError("Vehicle missing CheckpointSystemVehicle script", gameObject); }
    }

    void Update()
    {
        //get position of targetCheckpoint in localspace relative to AI vehicle
        Vector3 lookPos = myVehicle.transform.InverseTransformPoint(checkpointSystem.currentCheckpointTarget.transform.position);
        SetTurnDirection(Mathf.Clamp(lookPos.x, -1, 1));    //always look towards target checkpoint
        SetForwardSpeed(1); //move towards targetCheckpoint
    }
}
