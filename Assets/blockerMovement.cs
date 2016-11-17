using UnityEngine;
using System.Collections;

public class blockerMovement : MonoBehaviour {

    public bool isMoveDown;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (isMoveDown)
        {
            this.gameObject.transform.localPosition = this.gameObject.transform.localPosition + new Vector3(0, 0, 0.01f);
        }
        else
        {
            this.gameObject.transform.localPosition = this.gameObject.transform.localPosition - new Vector3(0, 0, 0.01f);
        }

        if (this.gameObject.transform.localPosition.z < -0.44)
        {
            isMoveDown = true;    
        }

        if (this.gameObject.transform.localPosition.z > 0.44)
        {
            isMoveDown = false;
        }
	}
}
