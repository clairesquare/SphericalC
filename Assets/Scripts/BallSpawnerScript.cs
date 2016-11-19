using UnityEngine;
using System.Collections;

public class BallSpawnerScript : MonoBehaviour {

	public GameObject ballPrefab;

	void Start()
	{
		SpawnNewBall ();
	}

	void SpawnNewBall()
	{
		Instantiate (ballPrefab, transform.position, Quaternion.identity);
	}
}
