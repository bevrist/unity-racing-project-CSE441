using UnityEngine;
using System.Collections;

public class BallKartMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float turnSpeed = 50;
    public float speed = 10;

    void Update()
    {
        float turnDirection = Input.GetAxis("Horizontal");
        transform.position = rb.transform.position;
        transform.Rotate(new Vector3(0, turnDirection * turnSpeed * Time.deltaTime, 0), Space.Self);
    }

    void FixedUpdate()
    {
        float moveVertical = Input.GetAxis("Vertical");
        rb.AddForce(transform.forward * speed * moveVertical);
    }
}