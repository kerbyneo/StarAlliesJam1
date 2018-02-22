using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerController : MonoBehaviour {

	private Rigidbody towerRB;
	public float centerMassHeight;
	public float forceHandicap;
	[Header ("Only works with handicap type 2")]
	public float velocityReduce;



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




		/* TYPES OF POSSIBLE HANDICAPPING FORCES */

		// TYPE 1: APPLYING A TORQUE TOWARD VECTOR3.ZERO AT ALL TIMES WITH MATHF.SIN
		// this one isn't that good, becuase it reduces the feel of gravity, and just seems janky in general

		/*
		// force handicap, becuase I guess normal balancing is quite difficult
		Vector3 handicapVector = (sinVector (this.transform.rotation.eulerAngles) * forceHandicap * -1);




		towerRB.AddTorque(handicapVector);

		Debug.DrawLine (Vector3.zero, handicapVector, Color.blue);
		Debug.DrawLine (Vector3.zero, this.transform.rotation.eulerAngles, Color.red);


		Debug.Log ("Euler Angles: " + this.transform.rotation.eulerAngles);

		Debug.Log ("Handicap Force: " +  handicapVector);
		*/

		// TYPE 2: REDUCING THE VELOCITY OF THE TOWER WHEN IT IS IN THE RANGE OF VECTOR3.ZERO
		// this one probably feels better, and could probably be combined with a drastic extra force on the pillar if the tower is really tipping


		if (this.transform.rotation.eulerAngles.magnitude < 10) {
			Vector3 handicapVector = (sinVector (this.transform.rotation.eulerAngles) * forceHandicap * -1);
			towerRB.velocity = towerRB.velocity * velocityReduce;
			towerRB.AddTorque(handicapVector);
		
		}



	}



	// a sign preserving operation, uses a vector3
	private Vector3 sinVector (Vector3 vector) {
		Vector3 newVector = Vector3.zero;

		// iterates through the dimensions of the vector3
		for (int i = 0; i < 3; i++) {

			newVector [i] = Mathf.Sin (vector [i]);

		}

		return newVector;
	}

}

