using UnityEngine;
using System.Collections;

public class StageTiltBlendScript : MonoBehaviour {

	// How steep the angle of the tilt is depending on which key is currently held.
	public float gentleSlopeMultiplier = 0.1f;
	public float middleSlopeMultiplier = 0.5f;
	public float steepSlopeMultiplier = 1f;

	// How quickly the environment rotates to the given steepness.
	public float rotationSpeed = 125.0f;

	Rigidbody rb;
	Vector3 targetRotation;
	Quaternion startingRotation;

	Animator animator;


	void Start() {
		animator = GetComponent<Animator> ();
	}


	void Update()
	{
		// HANDLE INPUT //

		// Get the slope multiplier based on the key being held.
		float slopeMultiplier = gentleSlopeMultiplier;

		if (Input.GetButton ("Middle Slope")) {
			slopeMultiplier = middleSlopeMultiplier;
		} else if (Input.GetButton ("Steep Slope")) {
			slopeMultiplier = steepSlopeMultiplier;
		}

		float blendTreeX = Input.GetAxis ("Horizontal") * slopeMultiplier;
		float blendTreeY = Input.GetAxis ("Vertical") * slopeMultiplier;

		animator.SetFloat ("axisX", blendTreeX);
		animator.SetFloat ("axisY", blendTreeY);
	}


	void FixedUpdate ()
	{
		// Move the rotation of the environment towards the target rotation.
//		Quaternion newRotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(targetRotation), rotationSpeed*Time.deltaTime);
//		rb.MoveRotation (newRotation);

		// Longxiao had this code commented out... I'm not sure what it does, but I left it here just in case we can use it later.  //

		//this.gameObject.GetComponent<Rigidbody>().AddRelativeTorque(0f, 0f, 100f);

		//this.gameObject.GetComponent<Rigidbody>().AddTorque(0f,0f,1f);

		//this.gameObject.GetComponent<Rigidbody>().AddForce(0f,0f,1f);
	}
}