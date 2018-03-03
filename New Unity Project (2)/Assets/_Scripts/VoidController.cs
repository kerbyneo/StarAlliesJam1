using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoidController : MonoBehaviour {


	public GameObject ballOb;


	
	void OnTriggerEnter(Collider trigger) {

	if (trigger.gameObject == ballOb) {
		
		ballOb.GetComponent<BallController> ().RespawnAll ();
		
		
	}


	}
}
