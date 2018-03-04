using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingWalkwayController : MonoBehaviour {

	private Rigidbody platformRB;
	private Vector3 startPos;
	private Vector3 parentStartPos;

	public Rigidbody sphereRB;

	private Vector3 startRot;

	public float bouyancyForce;
	public float maxBouyancyForce;

	public bool enableTravel = false;

	private bool doMovement = false; 
	private bool finishedMovement = false;
	public float travelDist = 44.5f;
	public float travelTime = 8f;
	public float playerForce = 10f;

	private float startTime;

	// Use this for initialization
	void Awake () {


		parentStartPos = this.transform.parent.position;
		startPos = this.transform.position;
		startRot = this.transform.rotation.eulerAngles;
		platformRB = this.GetComponent<Rigidbody> ();

	}
	
	// Update is called once per frame
	void FixedUpdate () {

		float force = bouyancyForce * (startPos.y - this.transform.position.y);

		if (force < 0) {
		
			force = 0;

		} else if (force > maxBouyancyForce) {
		
			force = maxBouyancyForce;

		}

		//Debug.Log ("Force :" + force);

		platformRB.AddForce (Vector3.up * force);


		if (doMovement) {
			
			float fracComplete = (Time.time - startTime) / travelTime;
			if (fracComplete > .99) {
				doMovement = false;
				finishedMovement = true;

				return;

			}
				

			this.transform.parent.position = Vector3.Lerp(parentStartPos,parentStartPos + new Vector3(-1 * travelDist, 0,0),fracComplete);

		}


	}

	void OnCollisionEnter(Collision collision) {
	
		if (collision.gameObject.name == "Sphere") {

			if (enableTravel && !finishedMovement) {

				if (!doMovement) {

					Debug.Log ("Start movement");

					startTime = Time.time;
					doMovement = true;
				}
			}
		}
	}


	void LateUpdate() {

		if (!enableTravel) {
			return;
		}


		Debug.Log ((this.transform.position - sphereRB.transform.position).magnitude);
		if ((this.transform.position - sphereRB.transform.position).magnitude < 7 && !finishedMovement) {
			if (sphereRB.transform.position.x > this.transform.position.x) {
				sphereRB.AddForce (Vector3.left * playerForce);

				Debug.Log ("Force added");
			}
		
		}
	}




	/*
	void OnCollisionStay(Collision collision) {
	
		if (collision.gameObject.name == "Sphere") {
			if (enableTravel) {
				if (doMovement) {

					sphereRB.AddForce (Vector3.left * playerForce);
				}
			}
		}
	}*/
					
	void Respawn() {
	

		doMovement = false;

		this.transform.parent.position = parentStartPos;

		this.transform.position = startPos;

		this.transform.rotation = Quaternion.Euler (startRot);

		platformRB.angularVelocity = Vector3.zero;
		platformRB.velocity = Vector3.zero;
	
	
	
	}
}
