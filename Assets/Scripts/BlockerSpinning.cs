using UnityEngine;
using System.Collections;

public class BlockerSpinning : MonoBehaviour {
    public Vector3 eulerAngleVelocity;
    public Rigidbody rb;
    
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        //this.gameObject.transform.localRotation = Quaternion.Lerp(this.gameObject.transform.localRotation, Quaternion.AngleAxis(360f, new Vector3(1f, 1f, 1f)), 5f);
        // this.gameObject.transform.localEulerAngles += new Vector3(1f, 1f, 1f);

        /*if (this.gameObject.transform.localEulerAngles.z < 0.1f)
        {
            this.gameObject.transform.localEulerAngles = new Vector3(0.1f, 0.1f, 0.1f);
        }*/
        Quaternion deltaRotation = Quaternion.Euler(eulerAngleVelocity * Time.deltaTime);
        rb.MoveRotation(rb.rotation * deltaRotation);    
     

	}
}
