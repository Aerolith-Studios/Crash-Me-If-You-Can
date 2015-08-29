using UnityEngine;
using System.Collections;

public class TokenGenerator : MonoBehaviour {

	public GameObject[] Tokens;
	public int tokensPerPlane = 10;
	

	// Use this for initialization
	void Start () {
	
		generateTokens ();

	}
	


	void generateTokens() {

		float halfWidth = transform.localScale.x * 5;
		float halfLength = transform.localScale.z * 5;

		for (int i = 1; i <= tokensPerPlane; i++) {

			float xPos = Random.Range (transform.position.x - halfWidth, transform.position.x + halfWidth);
			float yPos = Random.Range (0, 5.5f);
			float zPos = Random.Range (transform.position.z - halfLength, transform.position.z + halfLength);

			Vector3 newTokenPos = new Vector3 (xPos, yPos, zPos);

			int tokenChoice = Random.Range (0, Tokens.Length);
			GameObject newToken = Instantiate (Tokens[tokenChoice], newTokenPos, Tokens[tokenChoice].transform.rotation) as GameObject;
			newToken.transform.SetParent (transform.Find ("Tokens"));
		}

	}

}
