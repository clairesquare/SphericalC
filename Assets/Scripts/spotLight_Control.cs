using UnityEngine;
using System.Collections;

public class spotLight_Control : MonoBehaviour {
    public GameObject ballVector;
    //private Vector3 initEulerAngles;
	// Use this for initialization
	void Start () {
        //initEulerAngles = this.gameObject.transform.localEulerAngles;
	}
	
	// Update is called once per frame
	void Update ()
    {
        this.gameObject.transform.LookAt(ballVector.transform);

        //this.gameObject.transform.localEulerAngles = initEulerAngles + new Vector3(ballVector.gameObject.transform.position.x - this.gameObject.transform.position.x, ballVector.gameObject.transform.position.y - this.gameObject.transform.position.y, 0f) * 2f;
        //this.gameObject.transform.eulerAngles = Vector3.RotateTowards(this.gameObject.transform.position, ballVector.transform.position, 0f, 0f);

        //this.gameObject.transform.localEulerAngles = initEulerAngles + Vector3.RotateTowards(this.gameObject.transform.position, ballVector.transform.position, 300f, 100f);
    }
}
