using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class MainMenuUIScript : MonoBehaviour {
	
	public void StageSelection () {
		SceneManager.LoadScene("StageSelectionScene");
	}

	public void LoadTrial1 () {
        Time.timeScale = 1f;
		SceneManager.LoadScene("HandLevel 1");
	}

	public void LoadTrial2 () {
        Time.timeScale = 1f;
		SceneManager.LoadScene("Pushup Level 1");
	}

	public void LoadTrial3 () {
        Time.timeScale = 1f;
		SceneManager.LoadScene("Handstand Level 3");
	}

	public void LoadTrial4 () {
        Time.timeScale = 1f;
		SceneManager.LoadScene("HandLevel 2");
	}

    public void LoadTrial5 () {
        Time.timeScale = 1f;
		SceneManager.LoadScene("Pushup Level 2");
    }

	public void LoadTrial6 () {
		Time.timeScale = 1f;
		SceneManager.LoadScene("Handlevel 3");
	}

	public void LoadTrial7 () {
		Time.timeScale = 1f;
		SceneManager.LoadScene("Yoga Level 1");
	}

	public void LoadTrial8 () {
		Time.timeScale = 1f;
		SceneManager.LoadScene("Handstand Level 1");
	}

	public void LoadTrial9 () {
		Time.timeScale = 1f;
		SceneManager.LoadScene("Yoga Level 2");
	}

	public void LoadTrial10 () {
		Time.timeScale = 1f;
		SceneManager.LoadScene("Handstand Level 2");
	}

	public void LoadTrial11 () {
		Time.timeScale = 1f;
		SceneManager.LoadScene("Pushup Level 3");
	}

	public void LoadTrial12 () {
		Time.timeScale = 1f;
		SceneManager.LoadScene("Yoga Level 3");
	}

    public void LoadTutorial () {
        Time.timeScale = 1f;
		SceneManager.LoadScene("TutorialScene");
    }

	public void LoadMainMenu () {
		SceneManager.LoadScene("TitleScreenScene");
	}

	public void ExitGame () {
		Application.Quit ();
	}
}
