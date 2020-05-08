using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriveInACircleAi : VehicleController
{
    // Update is called once per frame
    void Update()
    {
        SetTurnDirection(Mathf.Clamp(Mathf.Cos(Time.time), 0, 1));
        SetForwardSpeed(0.75f);
    }
}
