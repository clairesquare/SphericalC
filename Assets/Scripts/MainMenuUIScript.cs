using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class MainMenuUIScript : MonoBehaviour {
	
	public void StageSelection () {
		SceneManager.LoadScene("StageSelectionScene");
	}

	public void LoadTrial1 () {
        Time.timeScale = 1f;
		SceneManager.LoadScene("Beta Stage 1");
	}

	public void LoadTrial2 () {
        Time.timeScale = 1f;
		SceneManager.LoadScene("Beta Stage 2");
	}

	public void LoadTrial3 () {
        Time.timeScale = 1f;
		SceneManager.LoadScene("Beta Stage 3");
	}

	public void LoadTrial4 () {
        Time.timeScale = 1f;
		SceneManager.LoadScene("Stage4Scene");
	}

    public void LoadTrial5 () {
        Time.timeScale = 1f;
		SceneManager.LoadScene("Stage5Scene");
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
