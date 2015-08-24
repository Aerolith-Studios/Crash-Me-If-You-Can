using UnityEngine;
using System.Collections;

public class GrassSpawning : MonoBehaviour {

	public Vector3 squarePos;  //world position of your square
	public Vector3 squareSize; //x = width, y = height, z = length of box
	public float squareBorder; //how far away from the edges you want the spawn to stay
	Vector3 realSquareSize;
	public GameObject GrassPrefab;
	public float grassDensity = 60;



	void Start()
	{
		realSquareSize = (squareSize - (Vector3.one * squareBorder));
		squarePos = transform.position;
		//SpawnPrefabOnSquare (GrassPrefab);
		StartCoroutine (SpawnGrass (GrassPrefab));
	}
		
	void SpawnPrefabOnSquare(GameObject thePrefabYouWantToSpawn){
		var spawnPos = squarePos + new Vector3(Random.Range(-realSquareSize.x, realSquareSize.x), squarePos.y, Random.Range(-realSquareSize.z, realSquareSize.z)) * 0.5f;
		Instantiate(thePrefabYouWantToSpawn, spawnPos, Quaternion.identity);
		}

	IEnumerator SpawnGrass(GameObject thePrefabYouWantToSpawn){
		while (grassDensity > 0) {
			var spawnPos = squarePos + new Vector3 (Random.Range (-realSquareSize.x, realSquareSize.x), squarePos.y+1.5f, Random.Range (-realSquareSize.z, realSquareSize.z)) * 0.5f;
			var spawnedGrass = Instantiate (thePrefabYouWantToSpawn, spawnPos, Quaternion.Euler(90, 180, 0)) as GameObject;
			spawnedGrass.transform.parent = gameObject.transform;
			grassDensity --;
		}
		yield return null;
	}
}
