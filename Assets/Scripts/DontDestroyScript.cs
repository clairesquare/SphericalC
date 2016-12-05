using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class DontDestroyScript : MonoBehaviour {

	void Awake ()
	{
		GameObject[] objs = GameObject.FindGameObjectsWithTag("Music");
		if (objs.Length > 1) {
			Destroy (gameObject);
		}

		DontDestroyOnLoad(gameObject);

	}

	void Update()
	{
//		if (SceneManager.GetActiveScene().name == "SceneName")
//		{
//			Destroy(gameObject);
//		}
	}
}
