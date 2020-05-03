using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class BallKartMovement : MonoBehaviour
{
    public float turnSpeed = 80;
    public float speed = 10;

    // variables meant to be accessed by controller script
    //public float turnDirection = 0;
    //public float moveVertical = 0;

    private Rigidbody rb;

    // create sphere to simulate physics on, adjust some paramaters of sphere, and store Rigidbody in variable
    void Start()
    {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = transform.position;
        rb = sphere.AddComponent(typeof(Rigidbody)) as Rigidbody;
        sphere.GetComponent<Rigidbody>().interpolation = RigidbodyInterpolation.Interpolate;
    }

    void Update()
    {
        float turnDirection = Input.GetAxis("Horizontal");
        transform.position = rb.transform.position; //make body "stick" to sphere position
        transform.Rotate(new Vector3(0, turnDirection * turnSpeed * Time.deltaTime, 0), Space.Self);
    }

    void FixedUpdate()
    {
        float moveVertical = Input.GetAxis("Vertical");
        rb.AddForce(transform.forward * speed * moveVertical);
    }


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