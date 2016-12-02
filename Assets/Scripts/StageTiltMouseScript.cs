using UnityEngine;
using System.Collections;

public class StageTiltMouseScript : MonoBehaviour {

	// How far the game will measure cursor movement.
	public float mouseRange = 25f;

	// How quickly the environment rotates to the given steepness.
	public float blendSpeed = 1f;

	// How quickly the blend vector 'steers' towards a new target direction.
	public float blendSteerForce = 0.01f;

	// How close blendLocation needs to be to blendTarget before it starts to slow down.
	public float blendArriveDistance = 0.25f;

	// How much to rotate the blend target.
	public float blendRotation = 0f;

	Vector2 blendLocation;
	Vector2 blendVelocity;
	Vector2 blendAcceleration;
	Vector2 blendTarget;

	Vector2 mouseMovement;

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

		if (Input.GetButtonDown ("Mouse Tilt") || Input.GetButtonUp("Mouse Tilt")) {
			mouseMovement *= 0f;
		}

		if (Input.GetButton ("Mouse Tilt")) {
			mouseMovement.x += Input.GetAxis ("Mouse X");
			mouseMovement.y += Input.GetAxis ("Mouse Y");
		}

		mouseMovement.x = Mathf.Clamp (mouseMovement.x, -mouseRange, mouseRange);
		mouseMovement.y = Mathf.Clamp (mouseMovement.y, -mouseRange, mouseRange);

		// Translate mouse coordinates to blend coordinates
		blendTarget *= 0;

		blendTarget.x = Mathf.Lerp (-1f, 1f, Mathf.InverseLerp (-mouseRange, mouseRange, mouseMovement.x));
		blendTarget.y = Mathf.Lerp (-1f, 1f, Mathf.InverseLerp (-mouseRange, mouseRange, mouseMovement.y));

		// Rotate blend target to match camera angle
		Vector3 dir = blendTarget - new Vector2 (0f,0f);
		dir = Quaternion.Euler (new Vector3 (0f, 0f, blendRotation))*dir;
		blendTarget = dir + (Vector3) blendTarget;

		Debug.Log (blendTarget);

		// HANDLE BLENDING //

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