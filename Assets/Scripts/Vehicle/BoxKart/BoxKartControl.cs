using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxKartControl : MonoBehaviour, IVehicleControllable
{
    private float angle = 0.0f;
    public float maxSpeed = 500.0f;
    public float maxAngle = 10.0f;
    public WheelCollider frontDriver, rearDriver, frontPassenger, rearPassenger;

    private float Horiz = 0;
    private float Vert = 0;

    void FixedUpdate()
    {
        //float Horiz = Input.GetAxis("Horizontal");
        //float Vert = Input.GetAxis("Vertical");

        angle = maxAngle * Horiz;

        frontDriver.steerAngle = angle;
        frontPassenger.steerAngle = angle;

        frontDriver.motorTorque = Vert * maxSpeed;
        frontPassenger.motorTorque = Vert * maxSpeed;
        rearDriver.motorTorque = Vert * maxSpeed;
        rearPassenger.motorTorque = Vert * maxSpeed;

    }

    //========== VehicleControllable Interface implementation ==========
    public void SetTurnDirection(float turnDirection)
    {
        this.Horiz = Mathf.Clamp(turnDirection, -1, 1);
    }

    public void SetForwardSpeed(float forwardSpeed)
    {
        this.Vert = Mathf.Clamp(forwardSpeed, -1, 1);
    }
    //========== END VehicleControllable Interface implementation ==========
}
