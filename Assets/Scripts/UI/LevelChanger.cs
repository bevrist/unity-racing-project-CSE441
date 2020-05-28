using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelChanger : MonoBehaviour
{
    public Animator animator;

    void Update()
    {


        
    }
    public void FadeToLevel (int levelIndex)
    {
        animator.SetTrigger("Fade_Out");
    }
}

