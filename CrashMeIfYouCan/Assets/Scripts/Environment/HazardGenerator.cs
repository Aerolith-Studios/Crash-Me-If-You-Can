using UnityEngine;
using System.Collections;

public class HazardGenerator : MonoBehaviour {
//
//	public GameObject[] Hazards; // List of Hazards set in the inspector.
//
//
////	public Stats statList;
////	float HazardDensity;
//	int HazardChoice;
////
////	void Start () {
////		generateHazards ();
////	}
//
////	void generateHazards() {
////
////		float planeLength = transform.localScale.z * 10;
////		float HazardDist = planeLength / GameObject.Find ("GM").GetComponent<Stats> ().HazardDensity;;
////		float spawnPos_HazardZ = Hazards [1].transform.position.z + (HazardDist / 2);
////
////		int [] spawnCount = new int[6];
////		while (spawnPos_HazardZ < (GetComponent<PlaneMover>().respawnDist)) {
////			HazardChoice = Random.Range (0, 6);
////
////			while (spawnCount[HazardChoice] >= 2) {
////				HazardChoice = Random.Range (0, 6);
////				print ("within choice loop");
////			}
////
////			spawnCount [HazardChoice] ++; // This is outside of the above while loop on purpose.
////			
////			GameObject RandomHazard = Hazards [HazardChoice];
////			Vector3 spawnPos_Hazard = new Vector3 (RandomHazard.transform.position.x, RandomHazard.transform.position.y, spawnPos_HazardZ);
////
////			GameObject newHazard = Instantiate (RandomHazard, spawnPos_Hazard, RandomHazard.transform.rotation) as GameObject;
////			newHazard.transform.parent = transform.FindChild ("Hazards");
////			spawnPos_HazardZ += HazardDist;
////		}
//	}
}
