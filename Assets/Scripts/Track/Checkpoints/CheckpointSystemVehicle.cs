using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//picks up list of checkpoints from static Checkpoints object, requires CheckpointEditor to be present in level
//attach this to vehicle which implements ICheckpointSystem
//this is responsible for tracking individual vehicle's next checkpoint and holds information about current lap
public class CheckpointSystemVehicle : MonoBehaviour
{
    public Checkpoint currentCheckpointTarget;  //holds the next checkpoint the player is driving to
    public int currentCheckpointInt;    //corresponds with Checkpoints.list for currentCheckpoint
    public int currentLapNumber = 0;    //counts the number of laps the player has made

    private ICheckpointSystemVehicle vehicleCS;    //reference to player vehicle witch has IcheckPointSystem implemented

    void Start()
    {
        vehicleCS = gameObject.GetComponent<ICheckpointSystemVehicle>();
        if (vehicleCS == null) { Debug.LogError("Vehicle does not implement ICheckpointSystemVehicle", gameObject); }
        if (Checkpoints.list.Length != 0)
        {
            Checkpoints.list[0].onCheckpointTriggered += OnCheckpointTriggered;
            currentCheckpointInt = 0;
            currentCheckpointTarget = Checkpoints.list[currentCheckpointInt];
        }
        else
        {
            currentCheckpointInt = -1;
        }

    }

    void OnCheckpointTriggered(Collider collider)
    {
        //check that collider is my vehicle
        if (collider.gameObject != vehicleCS.GetColliderGameObject())
        {
            return;
        }

        //move event listener from previous checkpoint to next checkpoint, loop if necessary
        Checkpoints.list[currentCheckpointInt].onCheckpointTriggered -= OnCheckpointTriggered;
        if (currentCheckpointInt >= Checkpoints.list.Length-1)    //loop back to 0 if necessary
        {
            currentLapNumber++;
            currentCheckpointInt = -1;
        }
        currentCheckpointInt++;
        Checkpoints.list[currentCheckpointInt].onCheckpointTriggered += OnCheckpointTriggered;
        currentCheckpointTarget = Checkpoints.list[currentCheckpointInt];
    }
}
