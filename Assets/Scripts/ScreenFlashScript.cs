using UnityEngine;
using System.Collections;

public class ScreenFlashScript : MonoBehaviour {

	Animator animator;

	void Start() {
		animator = GetComponent<Animator> ();
	}

	void FlashScreen() {
		animator.SetTrigger ("flash");
	}
}
