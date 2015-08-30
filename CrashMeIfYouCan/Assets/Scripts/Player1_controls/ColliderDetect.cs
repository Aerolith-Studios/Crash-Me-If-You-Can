using UnityEngine;
using System.Collections;

public class ColliderDetect : MonoBehaviour {
	
	int count;
	private int tokenChooser;

	Rigidbody RB_Main;
	public Rigidbody RB_Body;
	public Rigidbody RB_WheelLeft;
	public Rigidbody RB_WheelRight;
	public Collider Collider_Body;
	public Stats statList;

	public ParticleSystem tyreDirt_Left;
	public ParticleSystem tyreDirt_Right;

	public float ExplosionForce;
	public float ExplosionRadius;
	public float InvincibilityDuration = 5f;
	

	 bool invincible = false;

	// Use this for initialization
	void Start () {
		RB_Main = GetComponent<Rigidbody> ();
		RB_Main.isKinematic = false;
		RB_Body.isKinematic = true;
		RB_WheelLeft.isKinematic = true;
		RB_WheelRight.isKinematic = true;
		Collider_Body.isTrigger = true;

		invincible = false;

	
	}
	
	void OnTriggerEnter(Collider other) {

		if (other.gameObject.CompareTag ("gravitySwitch")) {
			statList.playerScore += 50;
			statList.gravitySwitcherCount ++;
			Destroy (other.gameObject);
		} else if (other.gameObject.CompareTag ("cameraFlip")) {
			statList.playerScore += 50;
			statList.cameraFlipCount ++;
			Destroy(other.gameObject);
		} else if (other.gameObject.CompareTag ("inverseController")) {
			statList.playerScore += 50;
			statList.invertControlCount ++;
			Destroy(other.gameObject);
		} else if (other.gameObject.CompareTag ("Invincible")) {
			StartCoroutine ("triggerInvincible");
			statList.playerScore ++;
			Destroy(other.gameObject);
		} else if (other.gameObject.CompareTag ("speedUp")) {
			statList.playerScore += 50;
			statList.speedUpCount ++;
			Destroy(other.gameObject);
		} else if (other.gameObject.CompareTag ("slowDown")) {
			statList.playerScore += 50;
			statList.slowDownCount ++;
			Destroy(other.gameObject);

		// Hazard collide event.
		} else if (other.gameObject.CompareTag ("Hazard") && (invincible == false)) {
			// Turn off the player's controls.
			gameObject.GetComponent<playerController>().enabled = false;
			// Open the game over window.
			GameObject.Find ("Canvas/Game/Game_Over_Window").SetActive(true);
			// Stop the Score Incrementer Coroutine.
			GameObject.Find ("GM").GetComponent<Stats>().StopCoroutine("ScoreIncrementer");
			// Stop the Speed Incrementer Coroutine.
			GameObject.Find ("GM").GetComponent<Stats>().StopCoroutine("SpeedIncrementer");

			RB_Main.isKinematic = true;
			RB_Body.isKinematic = false;
			RB_WheelLeft.isKinematic = false;
			RB_WheelRight.isKinematic = false;

			RB_Body.AddExplosionForce(ExplosionForce, other.transform.position, ExplosionRadius);
			RB_WheelLeft.AddExplosionForce(ExplosionForce, other.transform.position, ExplosionRadius);
			RB_WheelRight.AddExplosionForce(ExplosionForce, other.transform.position, ExplosionRadius);
			Collider_Body.isTrigger = false;

			tyreDirt_Left.Stop();
			tyreDirt_Right.Stop();
		}

	}

	IEnumerator triggerInvincible () {
		invincible = true;
		yield return new WaitForSeconds (InvincibilityDuration);
		invincible = false;
	}
}
