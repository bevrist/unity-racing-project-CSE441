using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverEffect : MonoBehaviour
{
    public float distance = 0.001f;
    public float speed = 0.001f;

    private float offset = 0;

    void Start(){
        offset = Random.Range(0,1000)/100;
    }

    void Update()
    {
        gameObject.transform.Translate(new Vector3(0,0,Mathf.Sin(Time.time + offset) * distance));
        offset += speed;
    }
}
