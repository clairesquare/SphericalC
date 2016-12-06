using UnityEngine;
using System.Collections;

public class PauseScript : MonoBehaviour {

	public GameObject pauseScreen;
	
	void Update () {
		if (Input.GetButtonDown("Pause")) {
			Time.timeScale = 0.0f;
			pauseScreen.SetActive (true);
		}
	}

	public void Unpause() {
		Time.timeScale = 1.0f;
		pauseScreen.SetActive (false);
	}
}
