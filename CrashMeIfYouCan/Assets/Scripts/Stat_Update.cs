using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Stat_Update : MonoBehaviour {


	private Stats stats;
	private Text text1;
	private Text text2;
	private Text text3;
	private Text text4;
	private Text text5;
	private Text scoreText;

	// Use this for initialization
	void Start () {
		stats = GameObject.Find ("GM").GetComponent<Stats> ();
		scoreText = GameObject.Find ("Canvas/Game/Score").GetComponent<Text> ();
		text1 = GameObject.Find ("Canvas/Game/gravitySwitcherCount/Text").GetComponent<Text> ();
		text2 = GameObject.Find ("Canvas/Game/cameraFlipCount/Text").GetComponent<Text> ();
		text3 = GameObject.Find ("Canvas/Game/invertControlCount/Text").GetComponent<Text> ();
		text4 = GameObject.Find ("Canvas/Game/speedUpCount/Text").GetComponent<Text> ();
		text5 = GameObject.Find ("Canvas/Game/slowDownCount/Text").GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		scoreText.text = stats.playerScore.ToString();
		text1.text = stats.gravitySwitcherCount.ToString();
		text2.text = stats.cameraFlipCount.ToString();
		text3.text = stats.invertControlCount.ToString();
		text4.text = stats.speedUpCount.ToString();
		text5.text = stats.slowDownCount.ToString();
	}
}
