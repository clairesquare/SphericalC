using UnityEngine;
using System.Collections;

public class UIScript : MonoBehaviour {
	

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void StageSelection () {
Application.LoadLevel("stage selection");
}

	public void trial1 () {
        Time.timeScale = 1f;
Application.LoadLevel("Stage1");
}

	public void trial2 () {
        Time.timeScale = 1f;
        Application.LoadLevel("Stage2");
}

	public void trial3 () {
        Time.timeScale = 1f;
        Application.LoadLevel("Stage3");
}
	public void trial4 () {
        Time.timeScale = 1f;
        Application.LoadLevel ("Stage4");
	}

    public void trial5()
    {
        Time.timeScale = 1f;
        Application.LoadLevel("Stage5");
    }

    public void Tutorial()
    {
        Time.timeScale = 1f;
        Application.LoadLevel("tutorial");
    }

    public void NextStage() {

}

	public void MainMenu(){
Application.LoadLevel("title screen");
}
}
