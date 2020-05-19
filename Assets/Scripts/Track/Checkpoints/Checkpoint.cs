using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[ExecuteInEditMode]
public class Checkpoint : MonoBehaviour
{
    public int checkpointNumber = -1;
    public float checkpointWidth = 6;

    GameObject leftCheckpointObject;
    GameObject rightCheckpointObject;
    GameObject triggerMesh;

    void Start()
    {
        CalculateCheckpointPoisitions();
    }

    void Update()
    {
        if (!Application.isPlaying) //run this code only in editor
        {
            CalculateCheckpointPoisitions();
        }
    }

    private void CalculateCheckpointPoisitions()
    {
        leftCheckpointObject = transform.GetChild(0).gameObject;
        rightCheckpointObject = transform.GetChild(1).gameObject;

        leftCheckpointObject.transform.position = transform.position + transform.right * -1 * (checkpointWidth / 2);
        rightCheckpointObject.transform.position = transform.position + transform.right * (checkpointWidth / 2);

        Debug.DrawLine(leftCheckpointObject.transform.position, (transform.up * 3f) + leftCheckpointObject.transform.position, Color.green);
        Debug.DrawLine(rightCheckpointObject.transform.position, (transform.up * 3f) + rightCheckpointObject.transform.position, Color.blue);

        triggerMesh = transform.GetChild(2).gameObject; //get box collider trigger child
        triggerMesh.transform.localPosition = new Vector3(0,1.5f,0);
        triggerMesh.transform.localScale = new Vector3(checkpointWidth, 3.0f, 0.2f);
    }

    //event dispatcher for whenever checkpoint is triggered by an object
    public event Action<Collider> onCheckpointTriggered;
    public void CheckpointTriggered(Collider collider)
    {
        if (onCheckpointTriggered != null)
        {
            onCheckpointTriggered(collider);
        }
    }

}
