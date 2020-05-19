using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointUX : MonoBehaviour
{
    [Tooltip("the prefab that will be spawned on active checkpoints so player can see it")]
    public GameObject activeCheckpointMarker;   //the prefab that will be spawned on active checkpoints so player can see it

    private CheckpointSystemVehicle playerCS;   //ref to checkpoint system on player
    private GameObject leftCheckpointMarker;
    private GameObject rightCheckpointMarker;

    void Start()
    {
        playerCS = GameObject.FindGameObjectWithTag("Player").GetComponent<CheckpointSystemVehicle>();
        if (playerCS == null) { Debug.LogError("Player vehicle does not implement CheckpointSystemVehicle!", gameObject); return; }

        leftCheckpointMarker = Instantiate(activeCheckpointMarker, playerCS.currentCheckpointTarget.leftCheckpointObject.transform);
        rightCheckpointMarker = Instantiate(activeCheckpointMarker, playerCS.currentCheckpointTarget.rightCheckpointObject.transform);

        CheckpointSystemVehicle.onCheckpointTriggeredByPlayer += PlayerUX;
    }

    void PlayerUX() {
        MoveCheckpointParticles();
        LapCounter();
    }

    void MoveCheckpointParticles()
    {
        leftCheckpointMarker.transform.position = playerCS.currentCheckpointTarget.leftCheckpointObject.transform.position;
        rightCheckpointMarker.transform.position = playerCS.currentCheckpointTarget.rightCheckpointObject.transform.position;

    }

    void LapCounter(){
        //this can be used to update the lap counter gui or whatever
        Debug.Log("Laps: " + playerCS.currentLapNumber + " CP: " + playerCS.currentCheckpointInt);
    }
}
