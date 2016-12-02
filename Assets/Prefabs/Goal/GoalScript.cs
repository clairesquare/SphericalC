using UnityEngine;
using System.Collections;

public class GoalScript : MonoBehaviour {

	public GameObject winScreenGameObject;

	// Delay between landing the ball in the hole and the win animation playing.
	public float winDelay;

	void OnTriggerEnter(Collider collider) {
		if (collider.tag == "Ball") {
			GetComponentInChildren<GoalLightPulsateScript> ().SendMessage ("WinPulse");
			Invoke ("WinLevel", winDelay);
		} 
	}

	void WinLevel() {
		winScreenGameObject.SetActive (true);
	}
}
