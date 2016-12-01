using UnityEngine;
using System.Collections;

public class GoalLightPulsateScript : MonoBehaviour {

	public Material lightShaftMaterial;
	public Material lightBottomMaterial;

	float lightShaftEmissionStart;
	float lightShaftOffsetStart;
	float lightBottomEmissionStart;

	void Start() {
		lightShaftEmissionStart = lightShaftMaterial.GetColor ("_EmissionColor").r;
		Debug.Log (lightShaftEmissionStart);
	}

	void Update () {
		
	}
}