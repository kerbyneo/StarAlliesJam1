﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoidController : MonoBehaviour {


	public GameObject blackFadeOB;
	
	void OnTriggerEnter(Collider trigger) {

		if (trigger.gameObject.name == "Sphere") {
		
			StartCoroutine(blackFadeOB.GetComponent<BlackFadeController> ().fadeBlackRespawn ());
		
		
		}


	}
}
