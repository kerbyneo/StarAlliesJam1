using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherController : MonoBehaviour {

	private bool touchedGround = false;
	private Archers_CountController countController;
	public GameObject towerTop;

	void Start() {
	
		countController = GameObject.Find ("Archers_Count").GetComponent<Archers_CountController> ();
	}
	
	// check if touched something under world
	void Update() {

		if (this.touchedGround) {
			return;
		}


		//Debug.Log (collision.gameObject.transform.root.gameObject.name.ToString());
		if ((towerTop.transform.position - this.transform.position).magnitude > 2) {
		
			countController.archerCount--;
			this.touchedGround = true;
		
		}
	}
}
