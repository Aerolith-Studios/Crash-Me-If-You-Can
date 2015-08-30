using UnityEngine;
using System.Collections;

public class Speedup : MonoBehaviour {

	public float speedUp = 1.5f;
	public float slowDown = 0.5f;
	public bool speedStatus = true;
	public bool speedStart = false;
	private Stats stats;


	// Use this for initialization
	void Start () {
		stats = GameObject.Find ("GM").GetComponent<Stats>();
	}
	
	// Update is called once per frame
	void Update () {
		if ((Input.GetKeyDown("5")) && (stats.speedUpCount > 0) && (speedStart == false)) {
//			print ("Triggered SPeed up");
			GameObject.Find ("IncreaseSpeedAudio").GetComponent<AudioSource>().Play();
			stats.planeSpeed = stats.planeSpeed * speedUp;
			speedStart = true;
			speedStatus = true;
			stats.speedUpCount--;
			StartCoroutine ("SpeedTimer");
			stats.playerScore += 300;
		}
		else if((Input.GetKeyDown ("4")) && (stats.slowDownCount > 0) && (speedStart == false)) {
//			print("Slowing");
			GameObject.Find ("DecreaseSpeedAudio").GetComponent<AudioSource>().Play();
			stats.planeSpeed = stats.planeSpeed * slowDown;
			speedStart = true;
			speedStatus = false;
			stats.slowDownCount--;
			StartCoroutine ("SpeedTimer");
			stats.playerScore -= 100;
		}
	}

	IEnumerator SpeedTimer(){
		while (speedStart == true) {
			yield return new WaitForSeconds (5f);
//			if (speedStatus == true) {
//				stats.planeSpeed = stats.planeSpeed * slowDown;
//			}
//			else if (speedStatus == false) {
//				stats.planeSpeed = stats.planeSpeed * speedUp;
//			}
			speedStart = false;
		}
	}
}