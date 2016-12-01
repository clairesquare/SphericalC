using UnityEngine;
using System.Collections;

public class ReparentScript : MonoBehaviour {

	void OnTriggerEnter(Collider collider) {
		if (collider.tag == "Ball") {
			collider.transform.parent = transform;
		}
	}
}
