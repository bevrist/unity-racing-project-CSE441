using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerInput : VehicleController
{
    private void Start()
    {
        Checkpoints.list[0].onCheckpointTriggered += ay;
    }

    void ay()
    {
        Debug.Log("ay");
    }


    void Update()
    {
        //simply set forward speed and steering according to player input
        SetTurnDirection(Input.GetAxis("Horizontal"));
        SetForwardSpeed(Input.GetAxis("Vertical"));
    }
}
