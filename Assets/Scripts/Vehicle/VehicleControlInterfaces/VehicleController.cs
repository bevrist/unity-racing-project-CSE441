using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//scripts which control a vehicle should inherit from this class
//this class provides methods for interfacing with a IVehicleControllable gameObject
public abstract class VehicleController : MonoBehaviour
{
    public GameObject myVehicle;   //vehicle being controlled
    private IVehicleControllable movementController;    //reference to vehicle controller script

    //to override Awake() in child classes use this code:
    //public override void Awake() { base.Awake(); //your code here..; }
    protected virtual void Awake()
    {
        // store reference to vehicle controller script in variable for fast access
        movementController = myVehicle.GetComponent<IVehicleControllable>();
    }

    //call this to set the current TurnDirection on the vehicle
    protected void SetTurnDirection(float turnDirection)
    {
        movementController.SetTurnDirection(turnDirection);
    }

    //call this to set the current ForwardSpeed on the vehicle
    protected void SetForwardSpeed(float forwardSpeed)
    {
        movementController.SetForwardSpeed(forwardSpeed);
    }

}
