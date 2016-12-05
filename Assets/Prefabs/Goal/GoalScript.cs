using UnityEngine;
using System.Collections;

public class GoalScript : MonoBehaviour {

	public GameObject winScreenGameObject;

	// Delay between landing the ball in the hole and the win animation playing.
	public float winDelay = 50f;

	public AudioSource ballInAudio;
	public AudioSource chargeAudio;
	public AudioSource winAudio;

	void OnTriggerEnter(Collider collider) {
		if (collider.tag == "Ball") {
			ballInAudio.Play ();
			chargeAudio.Play ();
			Camera.main.BroadcastMessage ("IncreaseShake", 0.1f);
			GetComponentInParent<GoalLightPulsateScript> ().SendMessage ("IncreasePulseStage");
			Invoke ("WinLevel", winDelay);
			Invoke ("StopAudio", 1.4f);
			collider.GetComponent<BallScript> ().SendMessage ("RemoveFromPlay");
			Destroy (collider.gameObject);
		} 
	}

	void StopAudio() {
		foreach (AudioSource audioSource in GetComponents<AudioSource>()) {
			audioSource.Stop ();
		}
	}

	void WinLevel() {
		winAudio.Play ();
		winScreenGameObject.SetActive (true);
	}
}
