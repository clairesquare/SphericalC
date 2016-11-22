using UnityEngine;
using System.Collections;

public class BouncerScript : MonoBehaviour {

	public float bounceForce = 5f;

	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.tag == "Ball") {
			Debug.Log ("Bounced.");
			collision.gameObject.GetComponent<Rigidbody>().velocity = collision.gameObject.GetComponent<Rigidbody>().velocity * -bounceForce;
		}
	}
}
