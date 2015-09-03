using UnityEngine;
using System.Collections;

public class GrassSpawning : MonoBehaviour {

	public float squareBorder; //how far away from the edges you want the spawn to stay
	public GameObject GrassPrefab;
	public float grassDensity = 60;
	public bool isGround = true;

	
	private Vector3 squarePos;  //world position of your square
	private Vector3 squareSize; //x = width, y = height, z = length of box
	private Quaternion spawnRot;
	private float spawnPosY;


	void Start() {
		squareSize = new Vector3 (transform.localScale.x * 8f, transform.localScale.y * 10f, transform.localScale.z * 10f);
		squareSize -= Vector3.one * squareBorder;
		squarePos = transform.position;
		SpawnGrass (GrassPrefab);
	}
		
	void SpawnGrass(GameObject thePrefabYouWantToSpawn){
		while (grassDensity > 0) {
			if (isGround == true)  {
				

				spawnPosY = squarePos.y + 1.5f;
				spawnRot = Quaternion.Euler(90, 180, transform.eulerAngles.z);
			} else {
				spawnPosY = squarePos.y - 13.5f;
				spawnRot = Quaternion.Euler(-90, 0, 0);
			}
			
			var spawnPos = squarePos + new Vector3 (Random.Range (-squareSize.x, squareSize.x), spawnPosY, Random.Range (-squareSize.z, squareSize.z)) * 0.5f;
			var spawnedGrass = Instantiate (thePrefabYouWantToSpawn, spawnPos, spawnRot) as GameObject;
			spawnedGrass.transform.parent = transform.FindChild("Tracks/Track_Forest");
			grassDensity --;
		}
	}
}


