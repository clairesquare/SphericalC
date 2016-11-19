using UnityEngine;
using System.Collections;

public class BallScript : MonoBehaviour {

	public GameObject spotlightPrefab;
	
    public GameObject youWinText;
	public GameObject youLoseText;


	void Start() {
		// SPAWN A NEW SPOTLIGHT //
		GameObject newSpotlight = (GameObject) Instantiate(spotlightPrefab, new Vector3(transform.position.x, transform.position.y + 10, transform.position.z), Quaternion.identity);
		newSpotlight.GetComponent<BallSpotlightScript> ().ballTransform = transform;
	}

	
	void OnCollisionEnter (Collision other) {
		if (other.gameObject.name == "Capsule"){
			this.gameObject.GetComponent<Rigidbody>().velocity = -3f*this.gameObject.GetComponent<Rigidbody>().velocity;
		}
	}

//    void OnTriggerEnter(Collider other)
//    {
//		if (other.gameObject.name == "Plane"){
//			youLoseText.SetActive(true);
//		}
//
//		if (other.gameObject.name == "Cylinder"){
//       		youWinText.SetActive(true);
//        	Invoke("TimeStop", 0.5f);
//		}
//    }

    void TimeStop()
    {
        Time.timeScale = 0f;
    }
}
