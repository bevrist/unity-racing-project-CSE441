using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointTrigger : MonoBehaviour
{
    private Checkpoint triggerEventReference;

    private void Start()
    {
        triggerEventReference = gameObject.transform.parent.GetComponent<Checkpoint>();
    }

    private void OnTriggerEnter(Collider other)
    {
        triggerEventReference.CheckpointTriggered();
    }
}
