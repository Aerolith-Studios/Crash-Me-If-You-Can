using UnityEngine;
using System.Collections;

public class playerController: MonoBehaviour {

	public float flipRotationSpeed = 3.0f;
	public GravitySwitcher gravSwitcher;
	public Stats statList;
	public bool isSwitching = false;
	public float distanceToMove;
	public bool isLerping;
	public float timeTakenDuringLerp = 0.4f;
	public Transform Body;
	

	int direction;
	float timeStartedLerping;
	Vector3 gravDown;
	Quaternion target;
	Vector3 startPos;
	Vector3 endPos;
	float YposLast;


	// Use this for initialization
	void Start () {
		gravDown = Physics.gravity.normalized;
		endPos = transform.position;
		statList = GameObject.Find ("GM").GetComponent<Stats>();

		GetComponent<Rigidbody> ().centerOfMass = Body.position;
	}
	
	// Update is called once per frame
	void Update () {

//		if( Input.GetKeyDown("2")&& statList.inverseControlCount > 0)
//		{
//			print ("Switch triggered");
//			isSwitching = true;
//		}
		YposLast = transform.position.y;

		if (isLerping == false) {
			transform.position = new Vector3 (endPos.x, YposLast, endPos.z);
		}

		if (Physics.gravity.normalized != gravDown) {
			target = Quaternion.Euler (0, 0, 180);
		} else {
			target = Quaternion.identity;
		}

//		if (transform.position.y > 1.33f) {
			transform.rotation = Quaternion.Lerp (transform.rotation, target, Time.deltaTime * flipRotationSpeed);
//		}

		if (gravSwitcher.isGrounded == true) {

			float keyInput = Input.GetAxisRaw ("Horizontal");

			if (statList.controlInverted = true) {
				keyInput *= -1;
			}

			if (keyInput < 0 && (transform.position.x < 2.5) && (isLerping == false) && (statList.invertControlCount >= 1)){
				direction = 1;
				startLerping ();
				//isSwitching = false;
//				print ("swithced");
			} else if (keyInput > 0 && (transform.position.x > -2.5) && (isLerping == false)) {
				direction = 0;
				startLerping ();
			}
		}
	
	}

	void startLerping() {
		isLerping = true;
		timeStartedLerping = Time.time;
		startPos = transform.position;

		if (direction == 0) {
			endPos = transform.position + Vector3.left * distanceToMove;

		} else if (direction == 1) {
			endPos = transform.position + Vector3.right * distanceToMove;

		}
	}

	void FixedUpdate() {
		if(isLerping)
		{
			float timeSinceStarted = Time.time - timeStartedLerping;
			float percentageComplete = timeSinceStarted / timeTakenDuringLerp;

			Vector3 lerPos = Vector3.Lerp ( startPos, endPos, percentageComplete);
			transform.position = new Vector3 (lerPos.x, YposLast, lerPos.z);

			if(percentageComplete >= 1.0f)
			{
				isLerping = false;
			}
		}
	}
}			                                
