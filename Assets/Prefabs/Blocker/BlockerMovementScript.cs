using UnityEngine;
using System.Collections;

public class BlockerMovementScript : MonoBehaviour {

	public float speed = 6f;
	public float movementRange = 0.44f;
	
    bool isMoveDown;
	
	void Update ()
    {
		if (isMoveDown) {
			gameObject.transform.localPosition = gameObject.transform.localPosition + new Vector3(0, 0, speed*Time.deltaTime);
        }

        else {
			gameObject.transform.localPosition = gameObject.transform.localPosition - new Vector3(0, 0, speed*Time.deltaTime);
        }

		if (gameObject.transform.localPosition.z < -movementRange) {
            isMoveDown = true;    
        }

		if (gameObject.transform.localPosition.z > movementRange) {
            isMoveDown = false;
        }
	}
}
