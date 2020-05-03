using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class BallKartMovement : MonoBehaviour, VehicleControllable
{
    public float turnSpeed = 80;
    public float speed = 10;

    // variables meant to be accessed by controller script
    private float turnDirection = 0;
    private float forwardSpeed = 0;

    private Rigidbody rb;

    void Start()
    {   // create sphere to simulate physics on, adjust some paramaters of sphere, and store Rigidbody in variable
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = transform.position;
        rb = sphere.AddComponent(typeof(Rigidbody)) as Rigidbody;
        sphere.GetComponent<Rigidbody>().interpolation = RigidbodyInterpolation.Interpolate;
    }

    void Update()
    {
        //float turnDirection = Input.GetAxis("Horizontal");
        transform.position = rb.transform.position; //make body "stick" to sphere position
        transform.Rotate(new Vector3(0, turnDirection * turnSpeed * Time.deltaTime, 0), Space.Self);
    }

    void FixedUpdate()
    {
        //float forwardSpeed = Input.GetAxis("Vertical");
        rb.AddForce(transform.forward * speed * forwardSpeed);
    }

    //========== VehicleControllable Interface implementation ==========
    public void SetTurnDirection(float turnDirection)
    {
        this.turnDirection = Mathf.Clamp(turnDirection, -1, 1);
    }

    public void SetForwardSpeed(float forwardSpeed)
    {
        this.forwardSpeed = Mathf.Clamp(forwardSpeed, -1, 1);
    }
    //========== END VehicleControllable Interface implementation ==========


#if UNITY_EDITOR
    // draw representation for sphere size and forward direction (editor only)
    [DrawGizmo(GizmoType.Selected | GizmoType.NonSelected)]
    static void drawGizmo2(BallKartMovement kart, GizmoType gizmoType)
    {
        Vector3 position = kart.transform.position;

        Gizmos.color = Color.red * 0.5f;
        Gizmos.DrawSphere(position, 0.5f);
        Gizmos.color = Color.red;
        Gizmos.DrawLine(position, kart.transform.forward * 1.5f + kart.transform.position);
    }
#endif
}