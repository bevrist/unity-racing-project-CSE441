using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointUX : MonoBehaviour
{
    // spawn particles on active checkpoint
    //have gui with lap counter?

    private CheckpointSystemVehicle playerCS;   //ref to checkpoint system on player
    [Tooltip("the prefab that will be spawned on active checkpoints so player can see it")]
    public GameObject activeCheckpointMarker;   //the prefab that will be spawned on active checkpoints so player can see it

    void Start()
    {
        playerCS = GameObject.FindGameObjectWithTag("Player").GetComponent<CheckpointSystemVehicle>();
        if (playerCS == null) { Debug.LogError("Player vehicle does not implement CheckpointSystemVehicle!", gameObject); }

    }

    void MoveCheckpointParticles(Checkpoint cp)
    {
        //spawn prefab if non existant, move prefab if exists

    }

    //gui with arrow?
}
