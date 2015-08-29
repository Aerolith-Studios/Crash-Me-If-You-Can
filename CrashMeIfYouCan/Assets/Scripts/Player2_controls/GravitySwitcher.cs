using UnityEngine;
using System.Collections;

public class GravitySwitcher : MonoBehaviour {

	public bool isGrounded = false;
	public int gravityScale = 3;
	public bool timerStarted = false;
	public bool gravitySwitchStart = false;
	public bool canSwitch = true;
	public playerController playCtrl;
	
	// Use this for initialization
	void Start () {

		Physics.gravity *= gravityScale;
	
	}

	IEnumerator groundedTimer() {


		yield return new WaitForSeconds (0.1f);
		if ((Physics.Raycast (transform.position, -transform.up, 1.15f)) == true) {
			isGrounded = true;
		}
		timerStarted = false;
	}

	// Update is called once per frame
	void Update () {

		Debug.DrawRay (transform.position, -transform.up * 1.15f, Color.red);

		if (isGrounded == false && timerStarted == false) {
			timerStarted = true;
			StartCoroutine ("groundedTimer");
		}

		if ((Input.GetKeyDown ("1")) && (canSwitch == true) && (isGrounded == true) && (timerStarted == false) && (GameObject.Find("GM").GetComponent<Stats>().gravitySwitcherCount > 0)) {
			Physics.gravity *= -1;
			isGrounded = false;
			GameObject.Find("GM").GetComponent<Stats>().gravitySwitcherCount--;
			GameObject.Find ("GravityAudio").GetComponent<AudioSource>().Play();
			gravitySwitchStart = true;
			StartCoroutine ("GravityTimer");
			GameObject.Find ("GM").GetComponent<Stats>().playerScore += 50;
		}
	}

	IEnumerator GravityTimer(){
		while (gravitySwitchStart == true) {
			canSwitch = false;
			yield return new WaitForSeconds (5f);
			canSwitch = true;
			gravitySwitchStart = false;
		}
	}
}
