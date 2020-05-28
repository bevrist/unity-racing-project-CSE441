using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public GameObject Paused; 

    public bool isPaused = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isPaused)
        {
            
            Paused.SetActive(true);
            Time.timeScale = 0f;
            
        }
        else
        {
            Paused.SetActive(false);
            Time.timeScale = 1f;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
        }
    }
    public void Restart()
    {
        Scene SampleScene;
         SampleScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(SampleScene.name);
    }
    public void Continue()
    {
        Paused.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void MainMenu(string MainMenu)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
