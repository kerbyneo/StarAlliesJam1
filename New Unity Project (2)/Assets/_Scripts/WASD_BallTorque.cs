using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WASD_BallTorque : MonoBehaviour {


	private Rigidbody ballRB;
	public float forceAmount = 1f;


	// Use this for initialization
	void Start () {
		
		// get the rigidbody
		ballRB = this.GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		// get player input, apply torque relative to the ball
		if (Input.GetKey (KeyCode.W)) {
		
			//Debug.Log("Forward Torque Added");
			ballRB.AddTorque (Vector3.forward * forceAmount);
		}

		if (Input.GetKey (KeyCode.D)) {
			//Debug.Log("Right Torque Added");
			ballRB.AddTorque (Vector3.right * forceAmount);
		}

		if (Input.GetKey (KeyCode.S)) {
			//Debug.Log("Left Torque Added");
			ballRB.AddTorque (Vector3.forward * forceAmount * -1);
		}
		if (Input.GetKey (KeyCode.A)) {
			//Debug.Log("Backward Torque Added");
			ballRB.AddTorque (Vector3.right * forceAmount * -1);
		}
	}
}
