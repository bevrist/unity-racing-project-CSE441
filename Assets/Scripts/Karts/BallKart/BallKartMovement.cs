using UnityEngine;
using System.Collections;

public class BallKartMovement : MonoBehaviour
{
    private bool player = true;

    public Rigidbody rb;
    public float turnSpeed = 50;
    public float speed = 10;

    private void Start()
    {
        if (gameObject.GetComponent<AIController>())
            player = false;
    }

    void Update()
    {
        float turnDirection = Input.GetAxis("Horizontal");
        if (player)
            Rotate(turnDirection);
    }

    void FixedUpdate()
    {
        float moveVertical = Input.GetAxis("Vertical");
        if (player)
            Forward(moveVertical);
    }

    void Rotate(float horizontal)
    {
        transform.position = rb.transform.position;
        transform.Rotate(new Vector3(0, horizontal * turnSpeed * Time.deltaTime, 0), Space.Self);
    }

    void Forward(float vertical)
    {
        rb.AddForce(transform.forward * speed * vertical);
    }
}