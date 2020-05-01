using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
    public float maxSpeed = 5.0f;
    public float maxAngle = 5.0f;
    public WheelCollider frontDriver, rearDriver, frontPassenger, rearPassenger;

    void FixedUpdate()
    {
        float Horiz = Input.GetAxis("Horizontal"), Vert = Input.GetAxis("Vertical");
        float angle = maxAngle * Horiz;

        frontDriver.steerAngle = angle;
        frontPassenger.steerAngle = angle;

        frontDriver.motorTorque = Vert * maxSpeed;
        frontPassenger.motorTorque = Vert * maxSpeed;
        
    }
}
