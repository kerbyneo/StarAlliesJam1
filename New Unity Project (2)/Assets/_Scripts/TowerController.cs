using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerController : MonoBehaviour {

	private Rigidbody towerRB;
	public float centerMassHeight;
	public float forceHandicap;


	// Use this for initialization
	void Start () {

		//get the rigidbody
		towerRB = this.GetComponent<Rigidbody> ();

		// set a new center of mass based on the user's input
		towerRB.centerOfMass = new Vector3 (0, centerMassHeight, 0);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		// draw a line to the center of mass
		Debug.DrawLine (Vector3.zero, towerRB.worldCenterOfMass);




		// force handicap, becuase I guess normal balancing is quite difficult
		Vector3 handicapVector = (signPreserveOP (this.transform.rotation.eulerAngles) * forceHandicap * -1);




		towerRB.AddTorque(handicapVector);

		Debug.DrawLine (Vector3.zero, handicapVector, Color.blue);
		Debug.DrawLine (Vector3.zero, this.transform.rotation.eulerAngles, Color.red);


		Debug.Log ("Euler Angles: " + this.transform.rotation.eulerAngles);

		Debug.Log ("Handicap Force: " +  handicapVector);

	}



	// a sign preserving operation, uses a vector3
	private Vector3 signPreserveOP (Vector3 vector) {
		Vector3 newVector = Vector3.zero;

		// iterates through the dimensions of the vector3
		for (int i = 0; i < 3; i++) {

			newVector [i] = Mathf.Sin (vector [i]);

		}

		return newVector;
	}

}

