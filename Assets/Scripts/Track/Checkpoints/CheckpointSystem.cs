using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//picks up list of checkpoints from static Checkpoints object, requires CheckpointEditor to be present in level
//attach this to vehicle which implements ICheckpointSystem
public class CheckpointSystem : MonoBehaviour
{
    private ICheckpointSystem vehicleCS;    //reference to player vehicle with IcheckPointSystem
    public Checkpoint currentCheckpointTarget;  //holds the next checkpoint the player is driving to
    public int currentCheckpointInt;    //corresponds with Checkpoints.list for currentCheckpoint
    public int currentLapNumber = 0;    //counts the number of laps the player has made

    void Start()
    {
        vehicleCS = gameObject.GetComponent<ICheckpointSystem>();
        if (vehicleCS == null) { Debug.LogError("GameObject does not implement ICheckpointSystem", gameObject); }
        if (Checkpoints.list.Length != 0)
        {
            SetNextCheckpoint(Checkpoints.list[0]);
            Checkpoints.list[0].onCheckpointTriggered += onCheckpointTriggered;
            currentCheckpointInt = 0;
        }
        else
        {
            currentCheckpointInt = -1;
        }

    }

    void SetNextCheckpoint(Checkpoint checkpoint)
    {
        currentCheckpointTarget = checkpoint;

    }

    void onCheckpointTriggered(Collider collider)
    {
        //check that collider is my vehicle
        if (collider.gameObject != vehicleCS.GetColliderGameObject())
        {
            return;
        }

        //move event listener from previous checkpoint to next checkpoint, loop if necessary
        Checkpoints.list[currentCheckpointInt].onCheckpointTriggered -= onCheckpointTriggered;
        if (currentCheckpointInt >= Checkpoints.list.Length-1)    //loop back to 0 if necessary
        {
            currentLapNumber++;
            currentCheckpointInt = -1;
        }
        currentCheckpointInt++;
        Checkpoints.list[currentCheckpointInt].onCheckpointTriggered += onCheckpointTriggered;
    }
}
