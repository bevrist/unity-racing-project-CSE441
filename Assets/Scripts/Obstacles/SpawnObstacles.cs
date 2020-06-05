using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class SpawnObstacles : MonoBehaviour
{
    
    TrapSpawn[] trapSpawnPoints;
    public GameObject[] trapList;
    List<TrapSpawn> spawnPoints;
    private CheckpointSystemVehicle playerCS;   //ref to checkpoint system on player

    void Start()
    {
        trapSpawnPoints = FindObjectsOfType<TrapSpawn>();
        spawnPoints = new List<TrapSpawn>();
        foreach (TrapSpawn item in trapSpawnPoints)
        {
            spawnPoints.Add(item);
        }
        Checkpoints.list[Checkpoints.list.Length-1].onCheckpointTriggered += SpawnTraps;
    }

    void SpawnTraps(Collider collider)
    {
        Random.seed = (int)System.DateTime.Now.Ticks;
        if (collider.gameObject.tag != "Player") { return; }
        int timesTorun = spawnPoints.Count/2;
        for (int i =0; i < timesTorun; i++)
        {
            int rand = Random.Range(0, spawnPoints.Count);
            TrapSpawn currentItem = spawnPoints[rand];
            spawnPoints.RemoveAt(rand);

            Instantiate(trapList[Random.Range(0,trapList.Length)], currentItem.transform.position, Quaternion.Euler(0,Random.Range(0,180),0));
        }
    }
}
