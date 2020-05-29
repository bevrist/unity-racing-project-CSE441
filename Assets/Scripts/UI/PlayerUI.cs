using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    private CheckpointSystemVehicle pCheckpoint;

    public GameObject player;
    public Text LapMonitor;

    // Start is called before the first frame update
    void Start()
    {
        if (!player)
            player = GameObject.FindGameObjectWithTag("Player");
        pCheckpoint = player.GetComponent<CheckpointSystemVehicle>();
    }

    private void Update()
    {
        LapMonitor.text = pCheckpoint.currentLapNumber + "/3";
    }
}
