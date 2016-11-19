using UnityEngine;
using System.Collections;

public class BallSpotlightScript : MonoBehaviour {
	
    public Transform ballTransform;

	void Update () {
		transform.LookAt(ballTransform);
    }
}
