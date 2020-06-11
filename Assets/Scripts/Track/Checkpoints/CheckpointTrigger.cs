using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this is attached to the checkpoint, dispatches Checkpoint.CheckPointTriggered() event
public class CheckpointTrigger : MonoBehaviour
{
    private Checkpoint checkpointObject;

    private void Start()
    {
        checkpointObject = gameObject.transform.parent.GetComponent<Checkpoint>();
    }

    private void OnTriggerEnter(Collider other)
    {
        checkpointObject.CheckpointTriggered(other);
    }
}
