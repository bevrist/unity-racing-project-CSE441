using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class BallKartMovement : MonoBehaviour, IVehicleControllable, ICheckpointSystemVehicle
{
    public float turnSpeed = 80;
    public float maxSpeed = 10;

    public ParticleSystem rocketParticles;  //particle effect to be used as trail

    private float currentMaxSpeed;

    // variables meant to be accessed by controller script
    private float turnDirection = 0;
    private float forwardSpeed = 0;

    public Rigidbody rb;

    void Start()
    {   // create sphere to simulate physics on, adjust some paramaters of sphere, and store Rigidbody in variable
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = transform.position;
        rb = sphere.AddComponent(typeof(Rigidbody)) as Rigidbody;
        sphere.GetComponent<Rigidbody>().interpolation = RigidbodyInterpolation.Interpolate;
        sphere.GetComponent<MeshRenderer>().enabled = false;
        currentMaxSpeed = maxSpeed;

        // add all components of vehicle to empty game object so that they are grouped together
        GameObject parentObj = new GameObject(gameObject.name);
        gameObject.transform.parent = parentObj.transform;
        rb.transform.parent = parentObj.transform;
        if (gameObject.tag == "Player")
        {
            rb.gameObject.tag = "Player";
        }
    }

    void Update()
    {
        transform.position = rb.transform.position; //make body "stick" to sphere position
        transform.Rotate(new Vector3(0, turnDirection * turnSpeed * Time.deltaTime, 0), Space.Self);

        //enable and disable particle effect
        ParticleSystem.EmissionModule em = rocketParticles.emission;
        em.enabled = (forwardSpeed > 0) ? true : false; //enable when forwardSpeed > 0

        //check tag of floor vehicle is over and apply speed changes
        if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, 2))
        {
            if (hit.collider.gameObject.tag == "Slow")
            {
                currentMaxSpeed = maxSpeed / 2;
            }
            else
            {
                currentMaxSpeed = maxSpeed;
            }
        }
    }

    void FixedUpdate()
    {
        rb.AddForce(transform.forward * currentMaxSpeed * forwardSpeed);
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

    //========== CheckpointSystem Interface implementation ==========
    public GameObject GetColliderGameObject()
    {
        return rb.gameObject;
    }
    //========== END CheckpointSystem Interface implementation ==========


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