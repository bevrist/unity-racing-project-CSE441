using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;

public class ToonyKart : MonoBehaviour
{
    public void OnUseItem()
    {
        Debug.Log("Fire!");
    }
    //public List<AxleInfo> axleInfos;
    //public float maxMotorTorque;
    //public float maxSteeringAngle;

    //// finds the corresponding visual wheel
    //// correctly applies the transform
    //public void ApplyLocalPositionToVisuals(WheelCollider collider)
    //{
    //    if (collider.transform.childCount == 0)
    //    {
    //        return;
    //    }

    //    Transform visualWheel = collider.transform.GetChild(0);

    //    Vector3 position;
    //    Quaternion rotation;
    //    collider.GetWorldPose(out position, out rotation);

    //    visualWheel.transform.position = position;
    //    visualWheel.transform.rotation = rotation;
    //}

    //public void FixedUpdate()
    //{
    //    float motor = maxMotorTorque * Input.GetAxis("Vertical");
    //    float steering = maxSteeringAngle * Input.GetAxis("Horizontal");

    //    foreach (AxleInfo axleInfo in axleInfos)
    //    {
    //        if (axleInfo.steering)
    //        {
    //            axleInfo.leftWheel.steerAngle = steering;
    //            axleInfo.rightWheel.steerAngle = steering;
    //        }
    //        if (axleInfo.motor)
    //        {
    //            axleInfo.leftWheel.motorTorque = motor;
    //            axleInfo.rightWheel.motorTorque = motor;
    //        }
    //        ApplyLocalPositionToVisuals(axleInfo.leftWheel);
    //        ApplyLocalPositionToVisuals(axleInfo.rightWheel);
    //    }
    //}
}



