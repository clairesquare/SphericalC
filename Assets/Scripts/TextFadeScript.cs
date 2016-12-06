using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextFadeScript : MonoBehaviour {

	Text text;
	float textFadeAmount = 0.01f;

	void Start () {
		text = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		text.color = new Color (text.color.r, text.color.g, text.color.b, text.color.a - textFadeAmount*Time.deltaTime);
		textFadeAmount *= 1.05f;
	}
}
