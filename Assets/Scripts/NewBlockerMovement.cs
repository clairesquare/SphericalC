using UnityEngine;
using System.Collections;

public class NewBlockerMovement : MonoBehaviour {

	public bool isMoveDown2;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update ()
	{
		if (isMoveDown2)
		{
			this.gameObject.transform.localPosition = this.gameObject.transform.localPosition + new Vector3(0.01f, 0, 0);
		}
		else
		{
			this.gameObject.transform.localPosition = this.gameObject.transform.localPosition - new Vector3(0.01f, 0, 0);
		}

		if (this.gameObject.transform.localPosition.x < -0.5)
		{
			isMoveDown2 = true;    
		}

		if (this.gameObject.transform.localPosition.x > 0.5)
		{
			isMoveDown2 = false;
		}
	}
}
