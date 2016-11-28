using UnityEngine;
using System.Collections;

public class StageTiltBlendScript : MonoBehaviour {

	// How steep the angle of the tilt is depending on which key is currently held.
	public float gentleSlopeMultiplier = 0.1f;
	public float middleSlopeMultiplier = 0.5f;
	public float steepSlopeMultiplier = 1f;

	// How quickly the environment rotates to the given steepness.
	public float blendSpeed = 1f;

	// How quickly the blend vector 'steers' towards a new target direction.
	public float blendSteerForce = 0.01f;

	// How close blendLocation needs to be to blendTarget before it starts to slow down.
	public float blendArriveDistance = 0.25f;

	Vector2 blendLocation;
	Vector2 blendVelocity;
	Vector2 blendAcceleration;
	Vector2 blendTarget;

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

		// Get a new blend target based on the directional keys being pressed.
		blendTarget *= 0;

		if (Input.GetAxisRaw ("Horizontal") < 0.0f) {
			blendTarget.x = -slopeMultiplier;
		} else if (Input.GetAxisRaw ("Horizontal") > 0.0f) {
			blendTarget.x = slopeMultiplier;
		} 

		if (Input.GetAxisRaw ("Vertical") < 0.0f) {
			blendTarget.y = -slopeMultiplier;
		} else if (Input.GetAxisRaw ("Vertical") > 0.0f) {
			blendTarget.y = slopeMultiplier;
		}

		// Get the direction to the blend target
		Vector2 desiredDirection = blendTarget - blendLocation;
		float distanceToDesiredDirection = desiredDirection.magnitude;
		desiredDirection.Normalize ();

		// If we're within a certain range of blendTarget, begin to slow down.
		if (distanceToDesiredDirection < blendArriveDistance) {
			float magnitude = Mathf.Lerp (0f, blendArriveDistance, Mathf.InverseLerp (0f, blendSpeed, distanceToDesiredDirection));
			desiredDirection *= magnitude;
		} else {
			desiredDirection *= blendSpeed;
		}

		// Steer towards blendTarget
		Vector2 blendSteer = desiredDirection - blendVelocity;
		blendSteer = Vector2.ClampMagnitude (blendSteer, blendSteerForce);

		// Update blendLocation
		blendVelocity += blendSteer;
		blendVelocity = Vector2.ClampMagnitude (blendVelocity, blendSpeed*Time.deltaTime);
		blendLocation += blendVelocity;

		// Update the animator with the new blend values.
		animator.SetFloat ("axisX", blendLocation.x);
		animator.SetFloat ("axisY", blendLocation.y);
	}


	// Currently unused
	float SimpleTween(float val1, float val2, float speed) {
		float distance = Mathf.Abs (val1 - val2);
		float newVal = distance * speed;
		return newVal;
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