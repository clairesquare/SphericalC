using UnityEngine;
using System.Collections;

public class EnvironmentTiltScript : MonoBehaviour {

	public float rotationSpeed = 10f;
	public float boostMultiplier = 2f;

	Rigidbody rb;

	void Start() {
		rb = GetComponent<Rigidbody> ();
	}


	void Update()
	{
		// Make sure the Y rotation is always 0. (For some reason, it kept getting rotated during FixedUpdate so I just made sure it is always reset to 0 no matter what.)
		Vector3 zeroYRotation = transform.eulerAngles;
		zeroYRotation.y = 0.0f;
		transform.rotation = Quaternion.Euler(zeroYRotation);
	}

	
	void FixedUpdate ()
	{
		// HANDLE INPUT //

		// I changed this section to make it more readable and to make it so that you can rotate diagonally by holding down two directions at once. -Dennis

		Vector3 newRotation = new Vector3 (0f, 0f, 0f);

		if (Input.GetAxisRaw("Horizontal") < 0.0f) {
			newRotation.z = rotationSpeed*Time.deltaTime;
        }

		else if (Input.GetAxisRaw("Horizontal") > 0.0f) {
			newRotation.z = -rotationSpeed*Time.deltaTime;
        }	

		if (Input.GetAxisRaw("Vertical") < 0.0f) {
			newRotation.x = -rotationSpeed*Time.deltaTime;
        }

		else if (Input.GetAxisRaw("Vertical") > 0.0f) {
			newRotation.x = rotationSpeed*Time.deltaTime;
        }

		if (Input.GetButton ("Rotation Speed Boost")) {
			newRotation *= boostMultiplier;
		}

		rb.MoveRotation(rb.rotation*Quaternion.Euler(newRotation));



		// Longxiao had this code commented out... I'm not sure what it does, but I left it here just in case we can use it later.

		//this.gameObject.GetComponent<Rigidbody>().AddRelativeTorque(0f, 0f, 100f);

		//this.gameObject.GetComponent<Rigidbody>().AddTorque(0f,0f,1f);

		//this.gameObject.GetComponent<Rigidbody>().AddForce(0f,0f,1f);
	}
}
