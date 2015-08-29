using UnityEngine;
using System.Collections;

public class HazardGenerator : MonoBehaviour {

	public Transform[] PlaceHolders;
	public GameObject[] forestHazards; 			// List of Forest Hazards set in the inspector.
	public GameObject[] roadHazards; 			// List of Road Hazards set in the inspector.
//	public GameObject[] desertHazards; 			// List of Desert Hazards set in the inspector.
	public GameObject[][] hazards; 				// List of Hazards set in the script.

//	private GameObject[,] hazardTypeArray = {forestHazards};

	int placeHolder_Choice;
	int hazardChoice;
	int hazardDensity;

	void Start () {
		hazards = new GameObject[][] {forestHazards, roadHazards};
		generateHazards (true);
//		BroadcastMessage ("generateHazards", true);
	}

	void generateHazards(bool firstSpawn = false) {

		/////////////////////////////////////////////////// CHOOSE AND CHANGE RANDOM TRACK TYPE ///////////////////////////////////////////////////

		// set all tracks on this plane to inactive.
		foreach (Transform track in transform.Find ("Tracks")) {
			track.gameObject.SetActive (false);
		}

		// Choose a random Hazard type (road, forest, desert etc) and set THAT track to active. Also used to change the hazard type at line 56.
		int trackType = Random.Range (0, hazards.Length);		
		transform.Find ("Tracks").GetChild (trackType).gameObject.SetActive (true);

		/////////////////////////////////////////////////// INSTANTIATE RANDOM HAZARDS BASED ON TRACK TYPE ///////////////////////////////////////////////////		

		// Get the plane length and divide by the GM/stats hazardDensity to find hazard spacing. Use the start of plane + half the Zspacing as originZ position.
		hazardDensity = GameObject.Find ("GM").GetComponent<Stats> ().HazardDensity;
		float planeLength = transform.localScale.z * 10;
		float hazardSpacingZ = planeLength / hazardDensity;
		float spawnPos_HazardZ = transform.position.z - planeLength / 2 + hazardSpacingZ / 2;

		// At the start of the game, the first spawn on the first planes (Top and Bottom) originate in the middle of the plane to give player a little time.
		if (firstSpawn == true && gameObject.CompareTag ("FirstPlane")) {
			spawnPos_HazardZ = transform.position.z;
		}
		
		int [] spawnCount = new int[6]; // Keeps track of how many times each hazard is instantiated per plane.
		
		// Loop instantiates a random hazard, moves forward by the spacing amount and then repeats until end of plane.
		while (spawnPos_HazardZ < transform.position.z + (planeLength / 2)) {
			
			// Choose a hazard randomly from the list, but make sure each hazard is instantiated no more than twice per plane. (should ammend this later to be function of density).
			placeHolder_Choice = Random.Range (0, 6);
			while (hazardDensity > 5 && (spawnCount[placeHolder_Choice] >= Mathf.FloorToInt(hazardDensity/5))) {									// <-- change to density/5 floored (mathf.FloorToInt(density/5)).
				placeHolder_Choice = Random.Range (0, 6);
			}

			spawnCount [placeHolder_Choice] ++; // This is outside of the above while loop on purpose. Limits the amount of duplicate placeHolders per plane.

			foreach (Transform child in PlaceHolders[placeHolder_Choice]) {

				// Pick a random hazard based on the track type and save as a GameObject.
				hazardChoice = Random.Range (0, hazards[trackType].Length);
				GameObject RandomHazard = hazards [trackType][hazardChoice];

				// Feed the object the placeHolder's xPos, the plane's yPos, and the newly generated zPos. The rotation is the object's own xRot & yRot, but the plane's zRot.
				Vector3 spawnPos_Hazard = new Vector3 (child.position.x, transform.position.y, spawnPos_HazardZ);
				Quaternion spawnRot_Hazard = Quaternion.Euler (RandomHazard.transform.eulerAngles.x, RandomHazard.transform.eulerAngles.y, transform.eulerAngles.z);
				
				// Instantiate the hazard and child it to the plane under "Hazards".
				GameObject newHazard = Instantiate (RandomHazard, spawnPos_Hazard, spawnRot_Hazard) as GameObject;
				newHazard.transform.name = "Hazard_" + spawnPos_HazardZ + "_" + RandomHazard.name;
				newHazard.transform.parent = transform.FindChild ("Hazards");
			}
			spawnPos_HazardZ += hazardSpacingZ; // loop updater & next HazardZ position.
		}
	}
}
