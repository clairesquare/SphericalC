using UnityEngine;
using System.Collections;

public class BallResetScript : MonoBehaviour {

	BallSpawnerScript ballSpawnerScript;

	AudioSource audioSource;

	void Start() {
		ballSpawnerScript = GameObject.Find ("Ball Spawner").GetComponent<BallSpawnerScript> ();
		audioSource = GetComponent<AudioSource> ();
	}

	void OnTriggerEnter(Collider collider) {

		if (collider.tag == "Ball" && collider.GetComponent<BallScript>().inPlay) {

			audioSource.Play ();

			collider.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f))*2f);
			collider.GetComponent<BallScript> ().SendMessage ("RemoveFromPlay");
			collider.GetComponent<BallScript> ().inPlay = false;
			ballSpawnerScript.SendMessage ("SpawnNewBall");
		}
	}
}
