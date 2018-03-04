using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingWalkwayController : MonoBehaviour {

	private Rigidbody platformRB;
	private Vector3 startPos;

	public float bouyancyForce;
	public float maxBouyancyForce;

	// Use this for initialization
	void Start () {

		startPos = this.transform.position;
		platformRB = this.GetComponent<Rigidbody> ();

	}
	
	// Update is called once per frame
	void FixedUpdate () {

		float force = bouyancyForce * (this.transform.position.y - startPos.y);

		if (force < 0) {
		
			force = 0;

		} else if (force > maxBouyancyForce) {
		
			force = maxBouyancyForce;

		}


		platformRB.AddForce(Vector3.up * 





	}
}
