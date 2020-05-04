using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerAI : VehicleController
{
    private GameObject playerVehicle;

    void Start()
    {
        //playerVehicle = Camera.main.GetComponent<SimpleCameraFollow>().target.gameObject; //latch onto object camera is targeting
        playerVehicle = GameObject.FindGameObjectsWithTag("Player")[0]; //latch onto the first tagged "Player" object
    }

    void Update()
    {
        //get position of player in localspace relative to AI vehicle
        Vector3 lookPos = myVehicle.transform.InverseTransformPoint(playerVehicle.transform.position);

        SetTurnDirection(Mathf.Clamp(lookPos.x, -1, 1));    //always look towards player
        SetForwardSpeed(Mathf.Clamp((lookPos.z-10)/10, -1, 1)); //try to always be 10 units away from player
    }
}
