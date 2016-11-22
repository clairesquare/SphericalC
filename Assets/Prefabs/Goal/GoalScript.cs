using UnityEngine;
using System.Collections;

public class GoalScript : MonoBehaviour {

	public GameObject winScreenGameObject;

	void OnTriggerEnter(Collider collider) {
		if (collider.tag == "Ball") {
			winScreenGameObject.SetActive (true);
		} 
	}
}
