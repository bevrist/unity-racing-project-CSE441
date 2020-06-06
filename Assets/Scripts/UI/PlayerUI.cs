using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    private CheckpointSystemVehicle pCheckpoint;

    public Image lapCounter;
    public Text timer;
    public Text win;
    public Text wintext;
    public GameObject player;
    public Sprite[] sprites;

    private float elapsedRunningTime = 0f;
    private float runningStartTime = 0f;
    private float pauseStartTime = 0f;
    private float elapsedPausedTime = 0f;
    private float totalElapsedPausedTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        if (!player)
            player = GameObject.FindGameObjectWithTag("Player");
        pCheckpoint = player.GetComponent<CheckpointSystemVehicle>();
        win.enabled = false;
        wintext.enabled = false;
    }

    private void Update()
    {
        //update timer text
        if (Time.timeScale != 0)
        {
            elapsedRunningTime = Time.time - runningStartTime - totalElapsedPausedTime;
        }
        else
        {
            elapsedPausedTime = Time.time - pauseStartTime;
        }
        timer.text = elapsedRunningTime.ToString("n2");

        if (pCheckpoint.currentLapNumber == 3) {
            Win();
            return;
        }
        if(sprites[pCheckpoint.currentLapNumber] != null && lapCounter.sprite != sprites[pCheckpoint.currentLapNumber])
            lapCounter.sprite = sprites[pCheckpoint.currentLapNumber];
        else if (pCheckpoint.currentLapNumber >= 3)
        {
            
        }
    }

    private void Win()
    {
        win.enabled = true;
        wintext.enabled = true;
        wintext.text = "Final Time: " + elapsedRunningTime.ToString("n2");
        Time.timeScale = 0.01f;
        FindObjectOfType<Pause>().isPaused = true;
    }
}
