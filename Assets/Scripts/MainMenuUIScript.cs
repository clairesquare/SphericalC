using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class MainMenuUIScript : MonoBehaviour {

	AudioSource audioSource;

	void Start() {
		audioSource = gameObject.AddComponent<AudioSource>();
		audioSource.clip = (AudioClip) Resources.Load ("Notification") as AudioClip;
		audioSource.volume = 0.7f;
		audioSource.pitch = 1.9f;
	}

	public GameObject stageSelection;
	public GameObject titleScreen;

	public void StageSelection () {
		audioSource.Play ();
		stageSelection.SetActive (true);
		titleScreen.SetActive (false);
	}

	public void LoadTrial1 () {
		Cursor.lockState = CursorLockMode.Confined;
		Cursor.visible = false;
		audioSource.Play ();
        Time.timeScale = 1f;
		SceneManager.LoadScene("HandLevel 1");
	}

	public void LoadTrial2 () {
		Cursor.lockState = CursorLockMode.Confined;
		Cursor.visible = false;
		audioSource.Play ();
        Time.timeScale = 1f;
		SceneManager.LoadScene("Pushup Level 1");
	}

	public void LoadTrial3 () {
		Cursor.lockState = CursorLockMode.Confined;
		Cursor.visible = false;
		audioSource.Play ();
        Time.timeScale = 1f;
		SceneManager.LoadScene("Handstand Level 3");
	}

	public void LoadTrial4 () {
		Cursor.lockState = CursorLockMode.Confined;
		Cursor.visible = false;
		audioSource.Play ();
        Time.timeScale = 1f;
		SceneManager.LoadScene("HandLevel 2");
	}

    public void LoadTrial5 () {
		Cursor.lockState = CursorLockMode.Confined;
		Cursor.visible = false;
		audioSource.Play ();
        Time.timeScale = 1f;
		SceneManager.LoadScene("Pushup Level 2");
    }

	public void LoadTrial6 () {
		Cursor.lockState = CursorLockMode.Confined;
		Cursor.visible = false;
		audioSource.Play ();
		Time.timeScale = 1f;
		SceneManager.LoadScene("Handlevel 3");
	}

	public void LoadTrial7 () {
		Cursor.lockState = CursorLockMode.Confined;
		Cursor.visible = false;
		audioSource.Play ();
		Time.timeScale = 1f;
		SceneManager.LoadScene("Yoga Level 1");
	}

	public void LoadTrial8 () {
		Cursor.lockState = CursorLockMode.Confined;
		Cursor.visible = false;
		audioSource.Play ();
		Time.timeScale = 1f;
		SceneManager.LoadScene("Handstand Level 1");
	}

	public void LoadTrial9 () {
		Cursor.lockState = CursorLockMode.Confined;
		Cursor.visible = false;
		audioSource.Play ();
		Time.timeScale = 1f;
		SceneManager.LoadScene("Yoga Level 2");
	}

	public void LoadTrial10 () {
		Cursor.lockState = CursorLockMode.Confined;
		Cursor.visible = false;
		audioSource.Play ();
		Time.timeScale = 1f;
		SceneManager.LoadScene("Handstand Level 2");
	}

	public void LoadTrial11 () {
		Cursor.lockState = CursorLockMode.Confined;
		Cursor.visible = false;
		audioSource.Play ();
		Time.timeScale = 1f;
		SceneManager.LoadScene("Pushup Level 3");
	}

	public void LoadTrial12 () {
		Cursor.lockState = CursorLockMode.Confined;
		Cursor.visible = false;
		audioSource.Play ();
		Time.timeScale = 1f;
		SceneManager.LoadScene("Yoga Level 3");
	}

    public void LoadTutorial () {
		Cursor.lockState = CursorLockMode.Confined;
		Cursor.visible = false;
		audioSource.Play ();
        Time.timeScale = 1f;
		SceneManager.LoadScene("TutorialScene");
    }

	public void LoadMainMenu () {
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
		audioSource.Play ();
		SceneManager.LoadScene("Title Scene");
	}

	public void ExitGame () {
		audioSource.Play ();
		Application.Quit ();
	}
}
