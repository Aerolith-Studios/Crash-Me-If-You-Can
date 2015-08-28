//using UnityEngine;
//using System.Collections;
//
//
//public class PlaneMover : MonoBehaviour {
//
//	public GameObject[] Hazards; // List of Hazards set in the inspector.
////	int HazardChoice;
//	public float respawnTrigger = -200;
//	public float respawnDist = 1600;
//
//	// Update is called once per frame
//	void Update () {
//
//		float PlaneSpeed = GameObject.Find ("GM").GetComponent<Stats> ().planeSpeed;
//
//		transform.position += Vector3.forward * -PlaneSpeed;
//		if (transform.position.z < respawnTrigger) {
//			transform.position += Vector3.forward * respawnDist;
//			// Destroy Hazards here.
//			
//			BroadcastMessage("generateHazards", false);
//		}
//	}
//}
