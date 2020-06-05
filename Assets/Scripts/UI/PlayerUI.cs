using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    private CheckpointSystemVehicle pCheckpoint;

    public Image lapCounter;
    public GameObject player;
    public Sprite[] sprites;

    // Start is called before the first frame update
    void Start()
    {
        if (!player)
            player = GameObject.FindGameObjectWithTag("Player");
        pCheckpoint = player.GetComponent<CheckpointSystemVehicle>();
    }

    private void Update()
    {
        if(sprites[pCheckpoint.currentLapNumber] != null && lapCounter.sprite != sprites[pCheckpoint.currentLapNumber])
            lapCounter.sprite = sprites[pCheckpoint.currentLapNumber];
        else if (pCheckpoint.currentLapNumber >= 3)
        {
            
        }
    }
}
