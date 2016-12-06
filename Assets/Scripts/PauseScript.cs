using UnityEngine;
using System.Collections;

public class PauseScript : MonoBehaviour {

	public GameObject pauseScreen;
	
	void Update () {
		if (Input.GetButtonDown("Pause")) {
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
			Time.timeScale = 0.0f;
			pauseScreen.SetActive (true);
		}
	}

	public void Unpause() {
		Cursor.lockState = CursorLockMode.Confined;
		Cursor.visible = false;
		Time.timeScale = 1.0f;
		pauseScreen.SetActive (false);
	}
}
