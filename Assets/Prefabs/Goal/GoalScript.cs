using UnityEngine;
using System.Collections;

public class GoalScript : MonoBehaviour {

	public GameObject winScreenGameObject;

	// Delay between landing the ball in the hole and the win animation playing.
	public float winDelay = 50f;

	void OnTriggerEnter(Collider collider) {
		if (collider.tag == "Ball") {
			GetComponentInParent<GoalLightPulsateScript> ().SendMessage ("WinPulseActivate");
			Invoke ("WinLevel", winDelay);
			collider.GetComponent<BallScript> ().SendMessage ("RemoveFromPlay");
			Destroy (collider.gameObject);
		} 
	}

	void WinLevel() {
		winScreenGameObject.SetActive (true);
	}
}
