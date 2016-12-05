using UnityEngine;
using UnityEditor;
using System.Collections;

public class GoalLightPulsateScript : MonoBehaviour {

	Material lightShaftMaterial;
	Material lightBottomMaterial;

	float lightShaftEmissionStart;
	float lightShaftOffsetStart;
	float lightBottomEmissionStart;

	float lightShaftEmissionCurrent;
	float lightShaftOffsetCurrent;
	float lightBottomEmissionCurrent;

	public float winPulseSpeed = 0.1f;
	int pulseStage = 0;
	public float pulseFrequency = 1f;
	public float emissionRange = 0.1f;
	public float minOffset = -0.12f;
	float sineTime;

	bool lightColorSaved = false;
	Color savedLightColor;
	float savedLightIntensity;

	AudioSource audioSource;

	void Start() {
		// Load the relevent assets
		lightShaftMaterial = (Material) AssetDatabase.LoadAssetAtPath("Assets/Materials/GradientMaterial.mat", typeof(Material));
		lightBottomMaterial = (Material) AssetDatabase.LoadAssetAtPath("Assets/Materials/LightBottomMaterial.mat", typeof(Material));

		// Get the starting values for each variable
		lightShaftEmissionStart = lightShaftMaterial.GetColor ("_EmissionColor").r;
		lightShaftOffsetStart = lightShaftMaterial.mainTextureOffset.y;
		lightBottomEmissionStart = lightBottomMaterial.GetColor ("_Color").r;

		audioSource = GetComponent<AudioSource> ();
	}

	void Update () {

		// Pulsing normally
		if (pulseStage == 0) {
			// Get the new sine value
			float sineValue = Mathf.Sin (sineTime);

			lightShaftEmissionCurrent = MyMath.Map (sineValue, -1f, 1f, lightShaftEmissionStart - emissionRange, lightShaftEmissionStart);
			lightShaftOffsetCurrent = MyMath.Map (sineValue, 1f, -1f, minOffset, lightShaftOffsetStart);
			lightBottomEmissionCurrent = MyMath.Map (sineValue, -1f, 1f, lightBottomEmissionStart - emissionRange * 3, lightBottomEmissionStart);

			// Update the sine time
			sineTime += pulseFrequency * Time.deltaTime;
		}

		// Increasing light
		else if (pulseStage == 1) {

			// Increase the emission of the light materials drastically. This happens when the ball
			// reaches the goal.
			lightShaftEmissionCurrent = Mathf.Lerp (lightShaftEmissionCurrent, 1f, winPulseSpeed);
			lightBottomEmissionCurrent = Mathf.Lerp (lightBottomEmissionCurrent, 1f, winPulseSpeed);

			if (lightBottomEmissionCurrent > 0.9999f) {
				Camera.main.BroadcastMessage ("IncreaseShake", 3.5f);
				SendMessage ("IncreasePulseStage");
				Invoke ("IncreasePulseStage", 3.5f);
			}

		}

		// Erupting light shaft
		else if (pulseStage == 2) {

			if (!lightColorSaved) {
				savedLightColor = GameObject.Find ("Directional Light").GetComponent<Light> ().color;
				savedLightIntensity = GameObject.Find ("Directional Light").GetComponent<Light> ().intensity;
				GameObject.Find ("Directional Light").GetComponent<Light> ().color = new Color (1f, 1f, 1f);
				GameObject.Find ("Directional Light").GetComponent<Light> ().intensity = 1.5f;
				audioSource.Play();
				lightColorSaved = true;
			}

			Camera.main.BroadcastMessage ("FlashScreen");
			Transform lightShaftTransform = GameObject.Find ("Light Shaft").transform;
			lightShaftTransform.localScale = new Vector3 (lightShaftTransform.localScale.x, 5f, lightShaftTransform.localScale.z);
			lightShaftTransform.localPosition = new Vector3 (lightShaftTransform.localPosition.x, 1f, lightShaftTransform.localPosition.z);
		}

		// Delete light shaft
		else if (pulseStage == 3) {
			audioSource.Stop ();
			Destroy(GameObject.Find ("Light Shaft"));
		}

		// Apply new values
		lightShaftMaterial.SetColor ("_EmissionColor", new Color (lightShaftEmissionCurrent, lightShaftEmissionCurrent, lightShaftEmissionCurrent));
		lightShaftMaterial.mainTextureOffset = new Vector2 (lightShaftMaterial.mainTextureOffset.x, lightShaftOffsetCurrent);
		lightBottomMaterial.SetColor ("_Color", new Color (lightBottomEmissionCurrent, lightBottomEmissionCurrent, lightBottomEmissionCurrent));
	}


	void IncreasePulseStage() {
		pulseStage += 1;
	}


	void FlashCamera() {
		
	}


	void OnDisable() {
		// Reset to original values
		lightShaftMaterial.SetColor("_EmissionColor", new Color(lightShaftEmissionStart, lightShaftEmissionStart, lightShaftEmissionStart));
		lightShaftMaterial.mainTextureOffset = new Vector2(lightShaftMaterial.mainTextureOffset.x, lightShaftOffsetStart);
		lightBottomMaterial.SetColor ("_Color", new Color (lightBottomEmissionStart, lightBottomEmissionStart, lightBottomEmissionStart));

//		GameObject.Find ("Directional Light").GetComponent<Light> ().color = savedLightColor;
//		GameObject.Find ("Directional Light").GetComponent<Light> ().intensity = savedLightIntensity;
	}
}