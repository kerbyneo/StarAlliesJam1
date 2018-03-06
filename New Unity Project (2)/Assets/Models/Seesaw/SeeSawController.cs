using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeeSawController : MonoBehaviour {


	private Quaternion initialRot;


	// Use this for initialization
	void Start () {
		initialRot = this.transform.rotation;
	}

	void Respawn() {
	
		this.transform.rotation = initialRot;
	
	}
}
