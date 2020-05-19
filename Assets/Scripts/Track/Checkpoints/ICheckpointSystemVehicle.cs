using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//all vehicles which work with the checkpoint system need to implement this class
public interface ICheckpointSystemVehicle
{
    GameObject GetColliderGameObject();  //return the GameObject that will be contacting the checkpoints
}
