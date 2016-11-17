using UnityEngine;
using System.Collections;

public class ball : MonoBehaviour {
    public GameObject youWinText;
	public GameObject youLoseText;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnCollisionEnter (Collision other) {
		Debug.Log("collide with" + other.gameObject.name);
		if (other.gameObject.name == "Capsule"){
			this.gameObject.GetComponent<Rigidbody>().velocity = -3f*this.gameObject.GetComponent<Rigidbody>().velocity;
	}
}

    void OnTriggerEnter(Collider other)
    {
        
		if (other.gameObject.name == "Plane"){
		youLoseText.SetActive(true);
}
		if (other.gameObject.name == "Cylinder"){
Debug.Log("collide with" + other.gameObject.name);
        youWinText.SetActive(true);
        Invoke("TimeStop", 0.5f);
}
    }

    void TimeStop()
    {
        Time.timeScale = 0f;
    }
}
