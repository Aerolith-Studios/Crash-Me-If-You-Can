using UnityEngine;
using System.Collections;


public class PlaneMover : MonoBehaviour {

	public GameObject[] Hazards; // List of Hazards set in the inspector.
//	int HazardChoice;
	public float respawnTrigger = -200;
	public float respawnDist = 1600;

	void Start () {
//		if (!gameObject.CompareTag ("FirstPlane")) {
			generateHazards (true);
//		}
	}

	// Update is called once per frame
	void Update () {

		float PlaneSpeed = GameObject.Find ("GM").GetComponent<Stats> ().planeSpeed;

		transform.position += Vector3.forward * -PlaneSpeed;
		if (transform.position.z < respawnTrigger) {
			transform.position += Vector3.forward * respawnDist;
			generateHazards();
		}
	}

	void generateHazards(bool firstSpawn = false) {

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
			int HazardChoice = Random.Range (0, 6);
			while (spawnCount[HazardChoice] >= 2) {
				HazardChoice = Random.Range (0, 6);
			}

			spawnCount [HazardChoice] ++; // This is outside of the above while loop on purpose.
			
			GameObject RandomHazard = Hazards [HazardChoice];
			Vector3 spawnPos_Hazard = new Vector3 (RandomHazard.transform.position.x, RandomHazard.transform.position.y, spawnPos_HazardZ);

			// Instantiate the hazard and child it to the plane under "Hazards".
			GameObject newHazard = Instantiate (RandomHazard, spawnPos_Hazard, RandomHazard.transform.rotation) as GameObject;
			newHazard.transform.parent = transform.FindChild ("Hazards");
			spawnPos_HazardZ += hazardSpacingZ; // loop updater & next HazardZ position.
		}
	}
}
