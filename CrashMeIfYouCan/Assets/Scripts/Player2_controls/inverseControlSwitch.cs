using UnityEngine;
using System.Collections;

public class inverseControlSwitch : MonoBehaviour {
	public Stats statList;

	// Use this for initialization
	void Start () {
		statList = GameObject.Find ("GM").GetComponent<Stats>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("2") && statList.invertControlCount > 0) {
			statList.invertControlCount--;
			statList.controlInverted = true;
			StartCoroutine ("InverseTimer");
		}
	
	}

	IEnumerator InverseTimer(){
		while (statList.controlInverted == true) {
			yield return new WaitForSeconds (10f);
			statList.controlInverted = false;
		}
	}
}