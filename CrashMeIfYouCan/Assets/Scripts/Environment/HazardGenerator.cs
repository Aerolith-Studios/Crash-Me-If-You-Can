using UnityEngine;
using System.Collections;

public class HazardGenerator : MonoBehaviour {

	public GameObject[] forestHazards; 			// List of Forest Hazards set in the inspector.
	public GameObject[] roadHazards; 			// List of Road Hazards set in the inspector.
//	public GameObject[] desertHazards; 			// List of Desert Hazards set in the inspector.
	public GameObject[][] hazards; 				// List of Hazards set in the script.

//	private GameObject[,] hazardTypeArray = {forestHazards};

	int HazardChoice;

	void Start () {
		hazards = new GameObject[][] {forestHazards, roadHazards};
		BroadcastMessage ("generateHazards", true);
	}

	void generateHazards(bool firstSpawn = false) {

		// set all tracks on this plane to inactive.
		foreach (Transform track in transform.Find ("Tracks")) {
			track.gameObject.SetActive (false);
		}

		// Choose a random Hazard type (road, forest, desert etc) and set THAT track to active. Also used to change the hazard type at line 56.
		int trackType = Random.Range (0, hazards.Length);		
		transform.Find ("Tracks").GetChild (trackType).gameObject.SetActive (true);

		// Get the plane length and divide by the GM/stats hazardDensity to find hazard spacing. Use the first Hazard in the list to get originZ position.
		float planeLength = transform.localScale.z * 10;
		float hazardSpacingZ = planeLength / GameObject.Find ("GM").GetComponent<Stats> ().HazardDensity;
		float spawnPos_HazardZ = transform.position.z - planeLength / 2;
		
		if (firstSpawn == true && gameObject.CompareTag ("FirstPlane")) {
			spawnPos_HazardZ = transform.position.z;
		}
		
		
		int [] spawnCount = new int[6]; // Keeps track of how many times each hazard is instantiated per plane.
		
		// Loop instantiates a random hazard, moves forward by the spaceing amount and then repeats until end of plane.
		while (spawnPos_HazardZ < transform.position.z + planeLength / 2) {
			
			// Choose a hazard randomly from the list, but make sure each hazard is instantiated no more than twice per plane. (should ammend this later to be function of density).
			int hazardChoice = Random.Range (0, 6);
			while (spawnCount[HazardChoice] >= 2) {
				HazardChoice = Random.Range (0, 6);
			}
			
			spawnCount [HazardChoice] ++; // This is outside of the above while loop on purpose.

			// Feed the object it's own xPos, the plane's yPos, and the newly generated zPos.
				// The rotation is the object's own xRot & yRot, but the plane's zRot.
			GameObject RandomHazard = hazards [trackType][hazardChoice];
			Vector3 spawnPos_Hazard = new Vector3 (RandomHazard.transform.position.x, transform.position.y, spawnPos_HazardZ);
			Quaternion spawnRot_Hazard = Quaternion.Euler (RandomHazard.transform.eulerAngles.x, RandomHazard.transform.eulerAngles.y, transform.eulerAngles.z);
			
			// Instantiate the hazard and child it to the plane under "Hazards".
			GameObject newHazard = Instantiate (RandomHazard, spawnPos_Hazard, spawnRot_Hazard) as GameObject;
			newHazard.transform.parent = transform.FindChild ("Hazards");
			spawnPos_HazardZ += hazardSpacingZ; // loop updater & next HazardZ position.
		}
	}
}
