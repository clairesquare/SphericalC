using UnityEngine;
using System.Collections;

public class BallResetScript : MonoBehaviour {

	BallSpawnerScript ballSpawnerScript;

	void Start() {
		ballSpawnerScript = GameObject.Find ("Ball Spawner").GetComponent<BallSpawnerScript> ();
	}

	void OnTriggerEnter(Collider collider) {
		if (collider.tag == "Ball") {
			ballSpawnerScript.SendMessage ("SpawnNewBall");
		}
	}
}
