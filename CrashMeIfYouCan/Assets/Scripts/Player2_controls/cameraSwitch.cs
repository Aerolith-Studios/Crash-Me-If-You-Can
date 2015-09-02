using UnityEngine;
using System.Collections;

public class cameraSwitch : MonoBehaviour {



	public bool canUseToken = true;
	public float speed = 5;

	private Stats stats;
	private Quaternion target = Quaternion.identity;
	

	// Use this for initialization
	void Start () {
		stats = GameObject.Find ("GM").GetComponent<Stats>();
	}
	
	// Update is called once per frame
	void Update () {
		if ((stats.cameraFlipCount > 0) && (canUseToken == true) && Input.GetKeyDown ("3")) {

			int rotateDirChoice = Random.Range(0,2);
			if(rotateDirChoice == 0){
				target = Quaternion.Euler (0, 0, 90);
			} else {
				target = Quaternion.Euler (0, 0, -90);
			}

			stats.cameraFlipCount--;
			StartCoroutine ("CameraFlipTimer");
			stats.playerScore += 50;
		}

		transform.rotation = Quaternion.Slerp (transform.rotation, target, Time.deltaTime * speed);
	}

	IEnumerator CameraFlipTimer(){
		canUseToken = false;
		yield return new WaitForSeconds (5f);
		target = Quaternion.identity;
		canUseToken = true;
	}
}
