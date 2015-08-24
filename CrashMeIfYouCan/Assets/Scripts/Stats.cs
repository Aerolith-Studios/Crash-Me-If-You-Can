using UnityEngine;
using System.Collections;

public class Stats : MonoBehaviour {

	// GUI variables.
	public int playerScore = 0;

	// Token Counters
	public int cameraFlipCount = 100;
	public int invertControlCount = 100;
	public int speedUpCount = 100;
	public int slowDownCount = 100;

	public bool controlInverted;

	// Controller variables.
	public float planeSpeed = 0.75f;

}
