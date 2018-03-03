using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerController : MonoBehaviour {

	private Rigidbody towerRB;
	public float centerMassHeight;
	[Header ("Works with all types of handicaps")]
	public float forceHandicap;
	[Header ("Only works with handicap type 2 & 3")]
	public float velocityReduce;
	[Header ("Only works with handicap type 3")]
	public float WASDTorque;
	[Header ("Only works with handicap type 5")]
	public float ForceHeight;



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
		//Debug.DrawLine (Vector3.zero, towerRB.worldCenterOfMass);



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
		// this one kinda feels wierd

		/*
		if (this.transform.rotation.eulerAngles.magnitude < 20) {

			towerRB.angularVelocity = towerRB.angularVelocity * velocityReduce;

		
		} else {
		
			Vector3 handicapVector = (sinVector (this.transform.rotation.eulerAngles) * forceHandicap * -1);
			towerRB.AddTorque(handicapVector);
		
		}

		*/



		// TYPE 3: CUSTOM CONDITIIONALS TO MAKE THE PLAYERS PREDICTICED ACTIONS MORE EFFECTIVE
		// this one probably odd, but better

		// get player input, apply torque relative to the ball

		/*

		if (this.transform.rotation.eulerAngles.magnitude > 30 && towerRB.velocity.magnitude > 2) {

			Debug.Log ("Applying handicap");
			if (Input.GetKey (KeyCode.W)) {

				//Debug.Log("Forward Torque Added");
				towerRB.AddTorque (Vector3.forward * WASDTorque * -1);
			}

			if (Input.GetKey (KeyCode.D)) {
				//Debug.Log("Right Torque Added");
				towerRB.AddTorque (Vector3.right * WASDTorque * -1);
			}

			if (Input.GetKey (KeyCode.S)) {
				//Debug.Log("Left Torque Added");
				towerRB.AddTorque (Vector3.forward * WASDTorque);
			}
			if (Input.GetKey (KeyCode.A)) {
				//Debug.Log("Backward Torque Added");
				towerRB.AddTorque (Vector3.right * WASDTorque);
			}
		}

		if (this.transform.rotation.eulerAngles.magnitude < 10 && towerRB.angularVelocity.magnitude < 2) {
			Debug.Log ("Applying small handicap");

			towerRB.velocity = towerRB.velocity * velocityReduce;
			Vector3 handicapVector = (sinVector (this.transform.rotation.eulerAngles) * forceHandicap * -1);
		
		}

		*/


		// TYPE 4: ADDING FORCE JUST UPWARD
		// decided to change the whole idea of the tower movement in general, so I guess this is what I am going with


		towerRB.AddForce (Vector3.up * forceHandicap);



		// TYPE 5: FORCE FROM POINT
		// who even knows these days

		/*

		towerRB.AddForceAtPosition(Vector3.up * forceHandicap,this.transform.position + new Vector3(0,ForceHeight,0));
		Debug.DrawLine (transform.position+Vector3.up,transform.position);
		*/

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

