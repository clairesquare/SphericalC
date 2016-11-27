using UnityEngine;
using System.Collections;

public class StageTiltScript : MonoBehaviour {

	// How steep the angle of the tilt is depending on which key is currently held.
	public float gentleAngleRadians = 10.0f;
	public float normalAngleRadians = 15.0f;
	public float steepAngleRadians = 30.0f;

	// How quickly the environment rotates to the given steepness.
	public float rotationSpeed = 125.0f;

	Rigidbody rb;
	Vector3 targetRotation;
	Quaternion startingRotation;


	void Start() {
		rb = GetComponent<Rigidbody> ();
		startingRotation = transform.rotation;
	}


	void Update()
	{
		// HANDLE INPUT //

		// Get the tilt steepness based on the angle key being held.
		float rotationAngle = normalAngleRadians;

		if (Input.GetButton ("Steep Angle")) {
			rotationAngle = steepAngleRadians;
		} else if (Input.GetButton ("Gentle Angle")) {
			rotationAngle = gentleAngleRadians;
		}

		// Reset the target rotation to the starting position.
		targetRotation = startingRotation.eulerAngles;

		// Modify the target rotation based on the direction keys currently being held.
		if (Input.GetAxisRaw ("Horizontal") < 0.0f) {
			targetRotation.z = rotationAngle;
		} else if (Input.GetAxisRaw ("Horizontal") > 0.0f) {
			targetRotation.z = -rotationAngle;
		}

		if (Input.GetAxisRaw ("Vertical") < 0.0f) {
			targetRotation.x = -rotationAngle;
		} else if (Input.GetAxisRaw ("Vertical") > 0.0f) {
			targetRotation.x = rotationAngle;
		}
	}

	
	void FixedUpdate ()
	{
		// Move the rotation of the environment towards the target rotation.
		Quaternion newRotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(targetRotation), rotationSpeed*Time.deltaTime);
		rb.MoveRotation (newRotation);

		// Longxiao had this code commented out... I'm not sure what it does, but I left it here just in case we can use it later.  //

		//this.gameObject.GetComponent<Rigidbody>().AddRelativeTorque(0f, 0f, 100f);

		//this.gameObject.GetComponent<Rigidbody>().AddTorque(0f,0f,1f);

		//this.gameObject.GetComponent<Rigidbody>().AddForce(0f,0f,1f);
	}
}