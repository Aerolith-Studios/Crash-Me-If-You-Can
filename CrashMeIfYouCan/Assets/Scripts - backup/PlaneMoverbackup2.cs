﻿//using UnityEngine;
//using System.Collections;
//
//
//public class PlaneMoverbackup2 : MonoBehaviour {
//
//	public GameObject[] Hazards; // List of Hazards set in the inspector.
//	int HazardChoice;
//
//
//	/* Prefabs*/
//
////	public GameObject obstacle1;
////	public GameObject obstacle2;
////	public GameObject obstacle3;
////	public GameObject obstacle4;
////	public GameObject obstacle5;
////	public GameObject obstacle6;
////
////	public GameObject token1;
////	public GameObject token2;
////	public GameObject token3;
////	public GameObject token4;
////	public GameObject token5;
////	public GameObject token6;
////
////	/* End Prefabs*/
////	public int randomToken;
////	public float aha;
//////	private int plainChooser;
////	private float RandomZ;
////	public bool enableGeneration;
////	public GameObject parent;
////	public GameObject child;
////	private int obstacleNum;
////	public float PlaneSpeed;
//	public float respawnTrigger;
//	public float respawnDist;
////	private int RandomNum;
//////	private int floorNum;
////	public int randomMax;
////	public int randomMin;
////	public Quaternion rotation;
////
////	/* Grass Spawning */
////
////	public Vector3 squarePos;  //world position of your square
////	public Vector3 squareSize; //x = width, y = height, z = length of box
////	public float squareBorder; //how far away from the edges you want the spawn to stay
////	Vector3 realSquareSize;
////	public GameObject GrassPrefab;
////	public float grassDensity = 100;
//
////	void Start () {
//////		floorNum = 1;
////		//print (transform.position);
//////		RandomNum = Random.Range (1, 6);
////
////	}
//	
//	// Update is called once per frame
//	void Update () {
//
//		float PlaneSpeed = GameObject.Find ("GM").GetComponent<Stats> ().planeSpeed;
//
//		transform.position += Vector3.forward * -PlaneSpeed;
//		if (transform.position.z < respawnTrigger) {
//
////			if (enableGeneration == true)
////			Generation();
////
////			if (floorNum == 1) {
////				floorNum = 2;
////			} else if (floorNum == 2)  {
////				floorNum = 3;
////			} else if (floorNum == 3) {
////				floorNum = 4;
////			} else if (floorNum == 4) {
////				floorNum = 1;
////			}
//			transform.position += Vector3.forward * respawnDist;
//			generateHazards();
////			gameObject.BroadcastMessage("generateHazards");
////			gameObject.BroadcastMessage("generateHazards");
////			gameObject.SendMessage("generateHazards");
////			GetComponent<HazardGenerator>().generateHazards();
////			BroadcastMessage ("hazardGenerator");
////			print ("just respawned and HazGen");
//		}
//	}
//
//	void generateHazards() {
//		
//		float planeLength = transform.localScale.z * 10;
//		float HazardDist = planeLength / GameObject.Find ("GM").GetComponent<Stats> ().HazardDensity;;
//		float spawnPos_HazardZ = Hazards [1].transform.position.z + (HazardDist / 2);
//		
//		int [] spawnCount = new int[6];
//		while (spawnPos_HazardZ < (GetComponent<PlaneMover>().respawnDist)) {
//			HazardChoice = Random.Range (0, 6);
//			
//			while (spawnCount[HazardChoice] >= 2) {
//				HazardChoice = Random.Range (0, 6);
//				print ("within choice loop");
//			}
//			
//			spawnCount [HazardChoice] ++; // This is outside of the above while loop on purpose.
//			
//			GameObject RandomHazard = Hazards [HazardChoice];
//			Vector3 spawnPos_Hazard = new Vector3 (RandomHazard.transform.position.x, RandomHazard.transform.position.y, spawnPos_HazardZ);
//			
//			GameObject newHazard = Instantiate (RandomHazard, spawnPos_Hazard, RandomHazard.transform.rotation) as GameObject;
//			newHazard.transform.parent = transform.FindChild ("Hazards");
//			spawnPos_HazardZ += HazardDist;
//		}
//
////	void Generation () {
////		Destroy (child);
//////		Debug.Log ("generation triggered, " + floorNum);
////		RandomNum = Random.Range (1,6);
////		RandomNum = Random.Range (1,6);
//////		plainChooser = Random.Range (1,2);
////		RandomZ = Random.Range (randomMin, randomMax);
////		parent = GameObject.Find("Bottom " + floorNum);
////		foreach (Transform childTransform in parent.transform) {
////			//GameObject.Destroy(child.gameObject);
////		}
////		switch (RandomNum) {
////		case 1 :
////			child = Instantiate(obstacle1, new Vector3(-2.5f, aha, RandomZ), rotation) as GameObject;
//////			print ("Creating Obstacle 1, my z is" + child.transform.position.z);
////			break;
////		case 2 :
////			child = Instantiate(obstacle2, new Vector3(-1.2f, aha, RandomZ), rotation) as GameObject;
//////			print ("Creating Obstacle 2");
////			break;
////		case 3 :
////			child = Instantiate(obstacle3, new Vector3(-2.5f, aha, RandomZ), rotation) as GameObject;
//////			print("Creating Obstacle 3");
////			break;
////		case 4 :
////			child = Instantiate(obstacle4,  new Vector3(2.5f, aha, RandomZ), rotation) as GameObject;
//////			print ("Creating Obstacle 4");
////			break;
////		case 5 :
////			child = Instantiate(obstacle5, new Vector3(0, aha, RandomZ), rotation) as GameObject;
//////			print ("Creating Obstacle 5");
////			break;
////		case 6 :
////			child = Instantiate(obstacle6, new Vector3(2.5f, aha, RandomZ), rotation) as GameObject;
//////			print ("Creating Obstacle 6");
////			break;
////		default :
//////			print ("There is somethig wrong with the switch/ randomNum");
////			break;
////
////		}
////		switch (randomToken) {
////		case 1 :
////			child = Instantiate(token1, new Vector3(-2.5f, aha, RandomZ), rotation) as GameObject;
////			break;
////		case 2 :
////			child = Instantiate(token1, new Vector3(0, aha, RandomZ), rotation) as GameObject;
////			break;
////		case 3 :
////			child = Instantiate(token1, new Vector3(1, aha, RandomZ), rotation) as GameObject;
////			break;
////		case 4 :
////			child = Instantiate(token1, new Vector3(-1, aha, RandomZ), rotation) as GameObject;
////			break;
////		case 5 :
////			child = Instantiate(token1, new Vector3(2, aha, RandomZ), rotation) as GameObject;
////			break;
////		case 6 :
////			child = Instantiate(token1, new Vector3(0, aha, RandomZ), rotation) as GameObject;
////			break;
////
////		}
//////		Debug.Log("generation complete");
////
////		//child = Instantiate(obstacle1);
////		child.transform.parent = parent.transform;
////
////	}
//}
