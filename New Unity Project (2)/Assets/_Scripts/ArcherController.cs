using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherController : MonoBehaviour {

	private bool touchedGround = false;
	private Archers_CountController countController;

	void Start() {
	
		countController = GameObject.Find ("Archers_Count").GetComponent<Archers_CountController> ();
	}
	
	// check if touched something under world
	void OnCollisionEnter(Collision collision) {

		if (this.touchedGround) {
			return;
		}



		//Debug.Log (collision.gameObject.transform.root.gameObject.name.ToString());
		if (collision.gameObject.transform.root.gameObject.name == "World") {
		
			countController.archerCount--;
			this.touchedGround = true;
		
		}
	}
}
