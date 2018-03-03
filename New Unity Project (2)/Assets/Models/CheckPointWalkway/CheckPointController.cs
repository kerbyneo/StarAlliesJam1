using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointController : MonoBehaviour {

	[Header ("Flags")]
	public GameObject flag1;
	public GameObject flag2;


	[Header ("Uncaptured and Captured Flag Materials")]
	public Material uncapturedFlag;
	public Material capturedFlag;


	bool playerReached = false;

	[Header ("Player Ball Object")]
	public GameObject ballObject;

	BallController ballController;

	private Vector3 CheckpointOffset = new Vector3(0,1,0);


	// Use this for initialization
	void Start () {


		flag1.GetComponent <Renderer>().material = uncapturedFlag;
		flag2.GetComponent <Renderer>().material = uncapturedFlag;

		ballController = ballObject.GetComponent<BallController> ();

	}


	void OnCollisionEnter(Collision collision) {

		Debug.Log ("Collided");

		if (playerReached) {
			return;
		}


		if (collision.gameObject.name == "Sphere") {
		
			playerReached = true;
			
			ballController.spawnPos = this.transform.position + CheckpointOffset;
		
			flag1.GetComponent <Renderer>().material = capturedFlag;
			flag2.GetComponent <Renderer>().material = capturedFlag;
		}
	}

}
