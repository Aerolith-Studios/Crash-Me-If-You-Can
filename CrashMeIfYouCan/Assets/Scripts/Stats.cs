using UnityEngine;
using System.Collections;

public class Stats : MonoBehaviour {

	// GUI variables.
	public int playerScore = 0;

	// Token Counters
	public int gravitySwitcherCount = 0;
	public int cameraFlipCount = 0;
	public int invertControlCount = 0;
	public int speedUpCount = 0;
	public int slowDownCount = 0;
	

	// Controller variables.
	public float planeSpeed = 0.75f;
	public bool controlInverted = false;

	// Hazard variables.
	public int HazardDensity = 5;

	// GameStarted bool.
	public bool gameStarted = true;

	void Start(){
		playerScore = 0;
		gravitySwitcherCount = 2;
		cameraFlipCount = 10;
		invertControlCount = 0;
		speedUpCount = 5;
		slowDownCount = 5;
		planeSpeed = 0.75f;
		controlInverted = false;
		HazardDensity = 5;
		gameStarted = true;
		StartCoroutine ("ScoreIncrementer");
		StartCoroutine ("SpeedIncrementer");
	}

	IEnumerator SpeedIncrementer() {
		bool speedIncrementing = true;
		while (speedIncrementing == true) {
			yield return new WaitForSeconds(1f);
			planeSpeed += 0.0078125f;
		}
	}

	IEnumerator ScoreIncrementer() {
		bool scoreIncrementing = true;
		while (scoreIncrementing == true) {
			yield return new WaitForSeconds(1f);
			playerScore += 50;
		}
	}

	void Update(){
		if ((Physics.gravity.y != -58.9) && (gameStarted == true)) {
			Physics.gravity = new Vector3 (0f, -58.9f, 0f);
			gameStarted = false;
		}
	}
}
