using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringTrap : MonoBehaviour, ITrap
{
    private BallKartMovement vehicle;
    public AudioSource audioSource;

    void OnTriggerEnter(Collider other)
    {
        vehicle = other.gameObject.transform.parent.GetComponentInChildren<BallKartMovement>();
        if (vehicle != null)
        {
            vehicle.rb.velocity = Vector3.zero;
            vehicle.rb.AddForce(new Vector3(0, 10, 0), ForceMode.Impulse);
            InvokeRepeating("StopMoving",0,0.001f);
            Invoke("Kill", 2.0f);
            transform.parent.GetComponent<Animation>().Play();
            audioSource.Play();
        }
    }

    int frames = 0;
    void StopMoving()
    {
        vehicle.SetForwardSpeed(-0.3f);
        if (frames > 400)
        {
            CancelInvoke("StopMoving");
        }
        frames++;
    }

    void Kill()
    {
        Destroy(transform.parent.gameObject);
    }
}
