using UnityEngine;
using System.Collections;

public class SkyBox_Rotator : MonoBehaviour {

	public float skyBoxRotateSpeed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		skyBoxRotateSpeed = GameObject.Find ("GM").GetComponent<Stats> ().planeSpeed;

		transform.Rotate (0, 0, -skyBoxRotateSpeed);
	
	}
}
