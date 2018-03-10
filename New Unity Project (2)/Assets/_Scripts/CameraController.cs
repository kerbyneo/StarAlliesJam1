using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public float flyInSpeed = 3;

	[Header ("Camera Position Offset is set to transform location")]
	[Space]
	public Vector3 cameraLookOffset = new Vector3(0F,.9F,0F);
	[Header ("Time to reach, larger is longer")]
	public float cameraSpeed = 1;

	public bool gameStart = false;


	public Vector3 cameraPositionOffset;

	public GameObject ballGO;

	public GameObject textController;

	private GameObject towerGO;
	private float startTime;


	// Use this for initialization
	void Awake () {


		towerGO = GameObject.Find ("CanonTower_Modified");

		cameraPositionOffset = cameraPositionOffset - towerGO.transform.position;
		startTime = Time.time;


	}
	
	// Update is called once per frame
	void FixedUpdate () {

		if (!gameStart) {
		



			return;
		
		}

		//Debug.DrawLine (this.transform.position, this.transform.position + this.transform.forward);

		//Debug.DrawLine (towerGO.transform.position, towerGO.transform.position + cameraLookOffset);

		Vector3 targetLocation = towerGO.transform.position + cameraPositionOffset;

		float fracComplete = (Time.time - startTime) / cameraSpeed;
		this.transform.position = Vector3.Slerp (this.transform.position, targetLocation, fracComplete);


		this.transform.LookAt (towerGO.transform.position + cameraLookOffset);
	}


	public void flyIn() {
	
		StartCoroutine(startFlyIn ());
	
	}


	private IEnumerator startFlyIn()
	{

		textController.GetComponent<FinishTextController> ().hideStartUI ();

		Vector3 targetLocation = towerGO.transform.position + cameraPositionOffset;
		float fracComplete = (Time.time - startTime) / flyInSpeed;

		float tempFlySpeed = flyInSpeed * .8f;


		float yOffset = 5f;

		Debug.Log ("Part 1 Started");
		while ((this.transform.position - targetLocation).magnitude > 4.8) {

			Debug.Log ((this.transform.position - targetLocation).magnitude + " " + yOffset.ToString());

			targetLocation = towerGO.transform.position + cameraPositionOffset + new Vector3(0, yOffset, 0);


			if (yOffset > 0)
				yOffset -= .06f;

			fracComplete = (Time.time - startTime) / tempFlySpeed;
			this.transform.position = Vector3.Lerp (this.transform.position, targetLocation, fracComplete);

			this.transform.LookAt (towerGO.transform.position + cameraLookOffset);

			yield return null;

		} 

		Debug.Log ("Part 2 Started");
		tempFlySpeed = flyInSpeed * .9f;

		while ((this.transform.position - targetLocation).magnitude > 1) {

			Debug.Log ((this.transform.position - targetLocation).magnitude + " " + yOffset.ToString());

			targetLocation = towerGO.transform.position + cameraPositionOffset + new Vector3(0,yOffset, 0);

			if (yOffset > 0)
				yOffset -= .06f;

			fracComplete = (Time.time - startTime) / tempFlySpeed;
			this.transform.position = Vector3.Lerp (this.transform.position, targetLocation, fracComplete);

			this.transform.LookAt (towerGO.transform.position + cameraLookOffset);

			yield return null;

		} 


		Debug.Log ("Part 3 Started");
		tempFlySpeed = flyInSpeed * .7f;

		while ((this.transform.position - targetLocation).magnitude > .01) {
		
			Debug.Log ((this.transform.position - targetLocation).magnitude + " " + yOffset.ToString());

			targetLocation = towerGO.transform.position + cameraPositionOffset + new Vector3(0,yOffset, 0);

			if (yOffset > 0)
				yOffset -= .06f;

			fracComplete = (Time.time - startTime) / tempFlySpeed;
			this.transform.position = Vector3.Lerp (this.transform.position, targetLocation, fracComplete);

			this.transform.LookAt (towerGO.transform.position + cameraLookOffset);
		
			yield return null;
		
		} 

		Debug.Log ((this.transform.position - targetLocation).magnitude);

		Debug.Log ("Game Start");
	
		textController.GetComponent<FinishTextController> ().showGameUI ();

		gameStart = true;
		ballGO.GetComponent<BallController> ().DO_INPUT = true;


	
	
		
	
	
	}



}
