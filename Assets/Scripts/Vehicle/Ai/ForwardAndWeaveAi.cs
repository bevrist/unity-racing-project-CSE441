using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForwardAndWeaveAi : VehicleController
{
    void Update()
    {
        SetForwardSpeed(Mathf.Clamp(Mathf.Cos(Time.time), 0.5f, 1));
        SetTurnDirection(Mathf.Cos(Time.time));
    }
}
