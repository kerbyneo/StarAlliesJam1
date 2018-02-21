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
	void Update () {
		
		// draw a line to the center of mass
		Debug.DrawLine (this.transform.localPosition, towerRB.worldCenterOfMass);


		// force handicap, becuase I guess normal balancing is quite difficult
		towerRB.AddTorque(this.transform.rotation.eulerAngles * -1 * forceHandicap);

		Debug.DrawLine (this.transform.localPosition, this.transform.rotation.eulerAngles * -1 * forceHandicap);

	}
}
