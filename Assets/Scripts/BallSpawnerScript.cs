using UnityEngine;
using System.Collections;

public class BallSpawnerScript : MonoBehaviour {

	public GameObject ballPrefab;
	public Color ballColor;

	AudioSource audioSource;

	void Start()
	{
		audioSource = GetComponent<AudioSource> ();
		SpawnNewBall ();
	}

	void SpawnNewBall()
	{
		audioSource.Play ();
		GameObject newBall = (GameObject) Instantiate (ballPrefab, transform.position, Quaternion.identity);
		newBall.transform.localScale = transform.localScale;
		newBall.GetComponent<MeshRenderer> ().material.color = ballColor;
		newBall.GetComponent<MeshRenderer> ().material.SetColor ("_EmissionColor", ballColor);
	}
}
