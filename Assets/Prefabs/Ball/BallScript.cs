using UnityEngine;
using System.Collections;

public class BallScript : MonoBehaviour {

	public GameObject spotlightPrefab;
	
    public GameObject youWinText;
	public GameObject youLoseText;

	Transform spotlightTransform;


	void Start() {
		// SPAWN A NEW SPOTLIGHT //
		GameObject newSpotlight = (GameObject) Instantiate(spotlightPrefab, new Vector3(transform.position.x, transform.position.y + 10, transform.position.z), Quaternion.identity);
		newSpotlight.GetComponent<BallSpotlightScript> ().ballTransform = transform;
		spotlightTransform = newSpotlight.transform;
	}


	void RemoveFromPlay() {
		// When this ball goes out of play delete its spotlight (And maybe do other things later)
		Destroy(spotlightTransform.gameObject);
	}
}
