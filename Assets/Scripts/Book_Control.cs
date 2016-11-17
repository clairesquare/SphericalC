using UnityEngine;
using System.Collections;

public class Book_Control : MonoBehaviour {

	public float rotationSpeed = 10f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	/*if (Input.GetKey(KeyCode.RightArrow))
        {
            this.gameObject.transform.localEulerAngles = this.gameObject.transform.localEulerAngles + new Vector3(0f, 0f, -1f);
        }
    if (Input.GetKey(KeyCode.LeftArrow))
        {
            this.gameObject.transform.localEulerAngles = this.gameObject.transform.localEulerAngles + new Vector3(0f, 0f, 1f);
        }
    if (Input.GetKey(KeyCode.UpArrow))
        {
            this.gameObject.transform.localEulerAngles = this.gameObject.transform.localEulerAngles + new Vector3(1f, 0f, 0f);
        }
    if (Input.GetKey(KeyCode.DownArrow))
        {
            this.gameObject.transform.localEulerAngles = this.gameObject.transform.localEulerAngles + new Vector3(-1f, 0f, 0f);
        }*/
    }
	
	void FixedUpdate ()
	{
		if (Input.GetKey(KeyCode.LeftArrow))
        {
            this.gameObject.GetComponent<Rigidbody>().MoveRotation(this.gameObject.GetComponent<Rigidbody>().rotation * (Quaternion.Euler(new Vector3(0f, 0f, rotationSpeed) * Time.deltaTime)));
        }
		else
		if (Input.GetKey(KeyCode.RightArrow))
        {
            this.gameObject.GetComponent<Rigidbody>().MoveRotation(this.gameObject.GetComponent<Rigidbody>().rotation * (Quaternion.Euler(new Vector3(0f, 0f, -rotationSpeed) * Time.deltaTime)));
        }	
		if (Input.GetKey(KeyCode.UpArrow))
        {
           	this.gameObject.GetComponent<Rigidbody>().MoveRotation(this.gameObject.GetComponent<Rigidbody>().rotation * (Quaternion.Euler(new Vector3(rotationSpeed, 0f, 0f) * Time.deltaTime)));
        }
   		 if (Input.GetKey(KeyCode.DownArrow))
        {
            this.gameObject.GetComponent<Rigidbody>().MoveRotation(this.gameObject.GetComponent<Rigidbody>().rotation * (Quaternion.Euler(new Vector3(-rotationSpeed, 0f, 0f) * Time.deltaTime)));
        }
		
		//this.gameObject.GetComponent<Rigidbody>().AddRelativeTorque(0f, 0f, 100f);

		//this.gameObject.GetComponent<Rigidbody>().AddTorque(0f,0f,1f);

		//this.gameObject.GetComponent<Rigidbody>().AddForce(0f,0f,1f);
	}
}
