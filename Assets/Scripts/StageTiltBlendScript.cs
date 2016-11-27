using UnityEngine;
using System.Collections;

public class StageTiltBlendScript : MonoBehaviour {

	// How steep the angle of the tilt is depending on which key is currently held.
	public float gentleSlopeMultiplier = 0.1f;
	public float middleSlopeMultiplier = 0.5f;
	public float steepSlopeMultiplier = 1f;

	// How quickly the environment rotates to the given steepness.
	public float blendSpeed = 0.01f;

	float blendX;
	float blendY;

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

		// Modify blend tree based on keys being held.
		float targetBlendX = 0.0f;
		float targetBlendY = 0.0f;

		if (Input.GetAxisRaw ("Horizontal") < 0.0f) {
			targetBlendX = -slopeMultiplier;
		} else if (Input.GetAxisRaw ("Horizontal") > 0.0f) {
			targetBlendX = slopeMultiplier;
		} else if (Input.GetAxisRaw ("Horizontal") == 0) {
			targetBlendX = 0.0f;
		}

		if (Input.GetAxisRaw ("Vertical") < 0.0f) {
			targetBlendY = -slopeMultiplier;
		} else if (Input.GetAxisRaw ("Vertical") > 0.0f) {
			targetBlendY = slopeMultiplier;
		} else if (Input.GetAxisRaw ("Vertical") == 0) {
			targetBlendY = 0.0f;
		}
			
		Debug.Log ("Target Blend X: " + targetBlendX + ", Target Blend Y: " + targetBlendY);
		Debug.Log ("Blend X: " + blendX + ", Blend Y: " + blendY);

		// Tween towards target blend.
		if (targetBlendX > blendX) {
			blendX += SimpleTween (blendX, targetBlendX, blendSpeed);
		} else if (targetBlendX < blendX) {
			blendX -= SimpleTween (blendX, targetBlendX, blendSpeed);
		}

		if (targetBlendY > blendY) {
			blendY += SimpleTween (blendY, targetBlendY, blendSpeed);
		} else if (targetBlendY < blendY) {
			blendY -= SimpleTween (blendY, targetBlendY, blendSpeed);
		}

		// Update the animator with the new blend values.
		animator.SetFloat ("axisX", blendX);
		animator.SetFloat ("axisY", blendY);
	}


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