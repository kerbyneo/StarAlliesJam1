using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherController : MonoBehaviour {

	private Vector3 initialLocation;
	private bool touchedGround = false;
	private Archers_CountController countController;
	public GameObject towerTop;

	void Awake() {
	
		initialLocation = this.transform.position - towerTop.transform.position;

		countController = GameObject.Find ("Archers_Count").GetComponent<Archers_CountController> ();
	}
	
	// check if touched something under world
	void Update() {




		if (this.touchedGround) {
			return;
		}


		//Debug.Log (collision.gameObject.transform.root.gameObject.name.ToString());
		if ((towerTop.transform.position - this.transform.position).magnitude > 1.8) {
		
			countController.archerCount--;
			this.touchedGround = true;
		
		}
	}

	public void Respawn() {
	
		this.GetComponent<Rigidbody> ().velocity = Vector3.zero;
		this.GetComponent<Rigidbody> ().angularVelocity = Vector3.zero;


		this.transform.position = initialLocation + towerTop.transform.position;
		this.transform.rotation = Quaternion.identity;

		Debug.Log (this.gameObject.name + this.transform.position.ToString ());

		this.touchedGround = false;
	
	
	}


}
