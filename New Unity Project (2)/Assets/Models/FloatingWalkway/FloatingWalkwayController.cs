using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingWalkwayController : MonoBehaviour {

	private Rigidbody platformRB;
	private Vector3 startPos;
	private Vector3 parentStartPos;

	private Vector3 startRot;

	public float bouyancyForce;
	public float maxBouyancyForce;

	public bool doTravel = false;
	public float travelDist = 44.5f;
	public float travelTime = 8f;

	private float startTime;

	// Use this for initialization
	void Start () {

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

	}

	void OnCollisionStay() {
	
		float fracComplete = (Time.time - startTime) / journeyTime;
		this.transform.parent.position = Vector3.Lerp(parentStartPos,parentStartPos + new Vector3(-1* travelDist, 0,0),
	
	
	
	
	}

	void Respawn() {
	
		this.transform.position = startPos;

		this.transform.rotation = Quaternion.Euler (startRot);

		platformRB.angularVelocity = Vector3.zero;
		platformRB.velocity = Vector3.zero;
	
	
	
	}
}
