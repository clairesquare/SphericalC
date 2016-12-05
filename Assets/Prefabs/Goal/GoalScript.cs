using UnityEngine;
using System.Collections;

public class GoalScript : MonoBehaviour {

	public GameObject winScreenGameObject;

	// Delay between landing the ball in the hole and the win animation playing.
	public float winDelay = 50f;

	AudioSource[] audioSources;

	void Start() {
		audioSources = GetComponents<AudioSource> ();
	}

	void OnTriggerEnter(Collider collider) {
		if (collider.tag == "Ball") {
			foreach (AudioSource audioSource in audioSources) {
				audioSource.Play ();
			}
			Camera.main.BroadcastMessage ("IncreaseShake", 0.1f);
			GetComponentInParent<GoalLightPulsateScript> ().SendMessage ("IncreasePulseStage");
			Invoke ("WinLevel", winDelay);
			Invoke ("StopAudio", 1.4f);
			collider.GetComponent<BallScript> ().SendMessage ("RemoveFromPlay");
			Destroy (collider.gameObject);
		} 
	}

	void StopAudio() {
		foreach (AudioSource audioSource in audioSources) {
			audioSource.Stop ();
		}
	}

	void WinLevel() {
		winScreenGameObject.SetActive (true);
	}
}
