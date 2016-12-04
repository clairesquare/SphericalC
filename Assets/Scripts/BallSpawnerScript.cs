using UnityEngine;
using System.Collections;

public class BallSpawnerScript : MonoBehaviour {

	public GameObject ballPrefab;
	public Color ballColor;

	void Start()
	{
		SpawnNewBall ();
	}

	void SpawnNewBall()
	{
		GameObject newBall = (GameObject) Instantiate (ballPrefab, transform.position, Quaternion.identity);
		newBall.transform.localScale = transform.localScale;
		newBall.GetComponent<MeshRenderer> ().material.color = ballColor;
	}
}
