using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishPointController : MonoBehaviour {


	bool playerReached = false;

	[Header ("Player Ball Object")]
	public GameObject ballObject;

	BallController ballController;


	// Use this for initialization
	void Awake () {

		ballController = ballObject.GetComponent<BallController> ();

	}


	void OnTriggerEnter(Collider trigger) {

		if (playerReached) {
			return;
		}

		if (trigger.gameObject.name == "Sphere") {
		
			this.capturePoint ();

		}
	}

	public void capturePoint() {
	
		playerReached = true;




		ballController.DO_INPUT = false;
	
	}
		

}
