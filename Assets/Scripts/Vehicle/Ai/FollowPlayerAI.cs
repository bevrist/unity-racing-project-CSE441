using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerAI : VehicleController
{
    private GameObject playerVehicle;
    private GameObject myVehicle;

    void Start()
    {
        playerVehicle = GameObject.FindGameObjectsWithTag("Player")[0]; //latch onto the first tagged "Player" object
        myVehicle = targetVehicle;  //store reference to own vehicle GameObject
    }


    void Update()
    {
        Vector3 lookPos = playerVehicle.transform.position - myVehicle.transform.position;
        Debug.Log(lookPos);
        //transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * damping);

        SetTurnDirection(Mathf.Clamp(lookPos.x, -1, 1));
        //SetForwardSpeed(1);
    }
}
