using UnityEngine;
using System.Collections;

public class Play_Button : MonoBehaviour {

	public void PlayGame() {		
		Application.LoadLevel ("Game Scene");
		
		Physics.gravity = new Vector3 (0f, -58.9f, 0f);
	}
}
