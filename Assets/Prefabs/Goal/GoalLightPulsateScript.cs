using UnityEngine;
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

	Timer lightTimer;

	void Start() {
		// Load the relevent assets
		lightShaftMaterial = (Material) Resources.Load("GradientMaterial") as Material;
		lightBottomMaterial = (Material) Resources.Load("LightBottomMaterial") as Material;

		// Get the starting values for each variable
		lightShaftEmissionStart = lightShaftMaterial.GetColor ("_EmissionColor").r;
		lightShaftOffsetStart = lightShaftMaterial.mainTextureOffset.y;
		lightBottomEmissionStart = lightBottomMaterial.GetColor ("_Color").r;

		audioSource = GetComponent<AudioSource> ();

		lightTimer = new Timer (0.0f);
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

			lightTimer.Update ();

			if (lightTimer.finished) {
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
		if (pulseStage == 1) {
			lightTimer.Set (1.5f);
		}
	}


	class Timer {
		float maxTime;
		float currentTime;
		public bool finished = false;
		public bool paused = false;

		public Timer (float _maxTime) {
			maxTime = _maxTime;
			currentTime = maxTime;
			paused = true;
		}

		public void Update() {

			if (paused) {
				return;	
			}

			if (currentTime > 0.0f) {
				currentTime -= Time.deltaTime;
			} else {
				finished = true;
				paused = true;
			}
		}

		public void Set(float _maxTime) {
			maxTime = _maxTime;
			currentTime = maxTime;
			finished = false;
			paused = false;
		}
			
		public void Reset() {
			paused = true;
			finished = false;
			maxTime = 0.0f;
			currentTime = maxTime;
		}
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