using UnityEngine;
using UnityEditor;
using System.Collections;
using UnityEngine.SceneManagement;


public class MainMenuUIScript : MonoBehaviour {

	AudioSource audioSource;

	void Start() {
		audioSource = gameObject.AddComponent<AudioSource>();
		audioSource.clip = (AudioClip) AssetDatabase.LoadAssetAtPath("Assets/Audio/menu/Notification.wav", typeof(AudioClip));
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
		audioSource.Play ();
        Time.timeScale = 1f;
		SceneManager.LoadScene("HandLevel 1");
	}

	public void LoadTrial2 () {
		audioSource.Play ();
        Time.timeScale = 1f;
		SceneManager.LoadScene("Pushup Level 1");
	}

	public void LoadTrial3 () {
		audioSource.Play ();
        Time.timeScale = 1f;
		SceneManager.LoadScene("Handstand Level 3");
	}

	public void LoadTrial4 () {
		audioSource.Play ();
        Time.timeScale = 1f;
		SceneManager.LoadScene("HandLevel 2");
	}

    public void LoadTrial5 () {
		audioSource.Play ();
        Time.timeScale = 1f;
		SceneManager.LoadScene("Pushup Level 2");
    }

	public void LoadTrial6 () {
		audioSource.Play ();
		Time.timeScale = 1f;
		SceneManager.LoadScene("Handlevel 3");
	}

	public void LoadTrial7 () {
		audioSource.Play ();
		Time.timeScale = 1f;
		SceneManager.LoadScene("Yoga Level 1");
	}

	public void LoadTrial8 () {
		audioSource.Play ();
		Time.timeScale = 1f;
		SceneManager.LoadScene("Handstand Level 1");
	}

	public void LoadTrial9 () {
		audioSource.Play ();
		Time.timeScale = 1f;
		SceneManager.LoadScene("Yoga Level 2");
	}

	public void LoadTrial10 () {
		audioSource.Play ();
		Time.timeScale = 1f;
		SceneManager.LoadScene("Handstand Level 2");
	}

	public void LoadTrial11 () {
		audioSource.Play ();
		Time.timeScale = 1f;
		SceneManager.LoadScene("Pushup Level 3");
	}

	public void LoadTrial12 () {
		audioSource.Play ();
		Time.timeScale = 1f;
		SceneManager.LoadScene("Yoga Level 3");
	}

    public void LoadTutorial () {
		audioSource.Play ();
        Time.timeScale = 1f;
		SceneManager.LoadScene("TutorialScene");
    }

	public void LoadMainMenu () {
		audioSource.Play ();
		SceneManager.LoadScene("Title Scene");
	}

	public void ExitGame () {
		audioSource.Play ();
		Application.Quit ();
	}
}
