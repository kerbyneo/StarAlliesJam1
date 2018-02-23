using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherController : MonoBehaviour {

	public bool touchedGround = false;
	
	// check if touched something under world
	void OnCollision(Collision collision) {
		if (collision.gameObject.transform.root.gameObject.name == "World") {
		
			this.touchedGround = true;
		
		}
	}
}
