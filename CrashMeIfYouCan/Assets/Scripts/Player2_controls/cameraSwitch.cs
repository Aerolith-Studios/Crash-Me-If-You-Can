using UnityEngine;
using System.Collections;

public class cameraSwitch : MonoBehaviour {

	public Stats stats;
	public Quaternion cameraStartRotation;
	public bool cameraFlipStart = false;

	// Use this for initialization
	void Start () {
		stats = GameObject.Find ("GM").GetComponent<Stats>();
		cameraStartRotation = gameObject.transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
		if ((stats.cameraFlipCount > 0) &&(cameraFlipStart == false)) {
			if (Input.GetKeyDown ("3")) {
				int tempNum = Random.Range(0,2);
				if(tempNum == 0){
					transform.Rotate (0, 0, 90);
				}
				else if (tempNum == 1) {
					transform.Rotate (0, 0, -90);
				}
				stats.cameraFlipCount--;
				cameraFlipStart = true;
				StartCoroutine ("CameraFlipTimer");
				stats.playerScore += 50;
			}
		}
	}

	IEnumerator CameraFlipTimer(){
		while (cameraFlipStart == true) {
			yield return new WaitForSeconds (5f);
			transform.localRotation = cameraStartRotation;
			cameraFlipStart = false;
		}
	}
}
