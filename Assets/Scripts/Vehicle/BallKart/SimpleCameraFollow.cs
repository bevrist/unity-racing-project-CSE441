using UnityEngine;
using System.Collections;

public class SimpleCameraFollow : MonoBehaviour
{
	public Transform target;
	public float distance = 7.0f;
	public float height = 3.0f;
	public float damping = 10.0f;
	public bool smoothRotation = true;
	public float rotationDamping = 10.0f;

	void LateUpdate()
	{
		Vector3 wantedPosition = target.TransformPoint(0, height, -distance);
		transform.position = Vector3.Lerp(transform.position, wantedPosition, Time.deltaTime * damping);

		if (smoothRotation)
		{
			Quaternion wantedRotation = Quaternion.LookRotation(target.position - transform.position, target.up);
			transform.rotation = Quaternion.Slerp(transform.rotation, wantedRotation, Time.deltaTime * rotationDamping);
		}
		else
		{
			transform.LookAt(target, target.up);
		}
	}
}