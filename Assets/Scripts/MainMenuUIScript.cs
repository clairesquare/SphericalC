using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class MainMenuUIScript : MonoBehaviour {
	
	public void StageSelection () {
		SceneManager.LoadScene("StageSelectionScene");
	}

	public void LoadTrial1 () {
        Time.timeScale = 1f;
		SceneManager.LoadScene("Stage1Scene");
	}

	public void LoadTrial2 () {
        Time.timeScale = 1f;
		SceneManager.LoadScene("Stage2Scene");
	}

	public void LoadTrial3 () {
        Time.timeScale = 1f;
		SceneManager.LoadScene("Stage3Scene");
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
