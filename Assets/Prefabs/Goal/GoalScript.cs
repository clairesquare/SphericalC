using UnityEngine;
using System.Collections;

public class GoalScript : MonoBehaviour {

	public GameObject winScreenGameObject;

	public AudioSource ballInAudio;
	public AudioSource chargeAudio;
	public AudioSource winAudio;

	void OnTriggerEnter(Collider collider) {
		if (collider.tag == "Ball" && collider.GetComponent<BallScript>().inPlay    ) {
			Camera.main.BroadcastMessage ("FlashScreen");
			ballInAudio.Play ();
			chargeAudio.Play ();
			GetComponentInParent<GoalLightPulsateScript> ().SendMessage ("IncreasePulseStage");
			Invoke ("WinLevel", 5f);
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
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
		winAudio.pitch = Random.Range (0.5f, 2.0f);
		winAudio.Play ();
		Debug.Log ("I tried to do this.");
		winScreenGameObject.SetActive (true);
	}
}
