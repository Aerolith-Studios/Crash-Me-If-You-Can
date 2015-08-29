using UnityEngine;
using System.Collections;

public class Play_Again_Button : MonoBehaviour {
	
	public void PlayAgain() {
		
		Application.LoadLevel ("Game Scene");
		Stats stats = GameObject.Find ("GM").GetComponent<Stats>();
		
		// GUI variables.
		stats.playerScore = 0;
		
		// Token Counters
		stats.cameraFlipCount = 0;
		stats.invertControlCount = 0;
		stats.speedUpCount = 0;
		stats.slowDownCount = 0;
		
		// Controller variables.
		stats.planeSpeed = 0.75f;
		stats.controlInverted = false;

		// Reset the Game Start.
		stats.gameStarted = true;

		Physics.gravity = new Vector3 (0f, -58.9f, 0f);
	}
}
