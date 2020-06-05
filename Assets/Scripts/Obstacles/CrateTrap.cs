using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateTrap : MonoBehaviour, ITrap
{
    private BallKartMovement vehicle;
    public AudioSource audioSource;

    void OnTriggerEnter(Collider other)
    {
        vehicle = other.gameObject.transform.parent.GetComponentInChildren<BallKartMovement>();
        if (vehicle != null)
        {
            vehicle.rb.velocity = Vector3.zero;
            InvokeRepeating("SpinAround", 0, 0.001f);
            Invoke("Kill", 0.15f);
            audioSource.Play();
        }
    }

    int frames = 0;
    void SpinAround()
    {
        vehicle.rb.velocity = Vector3.zero;
        if (frames > 400)
        {
            CancelInvoke("SpinAround");
        }
        frames++;
    }

    void Kill()
    {
        Destroy(gameObject);
    }
}
