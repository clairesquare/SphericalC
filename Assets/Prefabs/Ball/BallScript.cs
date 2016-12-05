using UnityEngine;
using System.Collections;

public class BallScript : MonoBehaviour {

	public GameObject spotlightPrefab;
	
    public GameObject youWinText;
	public GameObject youLoseText;

	public bool inPlay = true;

	Transform spotlightTransform;
	public AudioSource rollingAudio;
	public AudioSource bounceAudio;
	Rigidbody rigidbody;

	void Start() {
		// SPAWN A NEW SPOTLIGHT //
		GameObject newSpotlight = (GameObject) Instantiate(spotlightPrefab, new Vector3(transform.position.x, transform.position.y + 10, transform.position.z), Quaternion.identity);
		newSpotlight.GetComponent<BallSpotlightScript> ().ballTransform = transform;
		spotlightTransform = newSpotlight.transform;

		rigidbody = GetComponent<Rigidbody> ();
	}


	void Update() {
		// Set audio pitch based on current velocity
		if (rollingAudio.enabled) {
			rollingAudio.pitch = MyMath.Map(rigidbody.velocity.magnitude, 0f, 5f, 0.5f, 3f);
		}

		if (spotlightTransform != null) {
			spotlightTransform.gameObject.GetComponent<Light> ().intensity = MyMath.Map (
				rigidbody.velocity.magnitude, 0f, 3f, 0.3f, 1f
			);
			spotlightTransform.gameObject.GetComponent<Light> ().spotAngle = MyMath.Map (
				rigidbody.velocity.magnitude, 0f, 3f, 3f, 1f
			);
		}
	}


	void OnCollisionEnter(Collision collision) {
		if (collision.relativeVelocity.magnitude > 5f) {
			bounceAudio.pitch = Random.Range (0.5f, 1.5f);
			bounceAudio.Play ();
		}
	}


	void RemoveFromPlay() {
		// When this ball goes out of play delete its spotlight (And maybe do other things later)
		Destroy(spotlightTransform.gameObject);
		rollingAudio.enabled = false;
	}
}
