using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : VehicleController
{
    void Update()
    {
        //simply set forward speed and steering according to player input
        SetTurnDirection(Input.GetAxis("Horizontal"));
        SetForwardSpeed(Input.GetAxis("Vertical"));
    }
}
