using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//interface for any vehicle meant to receive input from a controller
public interface IVehicleControllable
{
    void SetTurnDirection(float turnDirection);   //set current turn direction [-1 to 1]
    void SetForwardSpeed(float forwardSpeed);    //set current forward speed [1 to -1]
}