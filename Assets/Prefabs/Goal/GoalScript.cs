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
			Camera.main.BroadcastMessage ("FlashScreen");
			ballInAudio.Play ();
			chargeAudio.Play ();
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
		winAudio.pitch = Random.Range (0.5f, 2.0f);
		winAudio.Play ();
		winScreenGameObject.SetActive (true);
	}
}
