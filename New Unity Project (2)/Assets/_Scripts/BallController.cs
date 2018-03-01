using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class BallController : MonoBehaviour {
    
	private Rigidbody ballRB;
    private bool onGround;
    public float jumpForce = 1.0f;
	private bool firstCollision = true;

	[Header ("Additional Gravity to Make up for Upward Force on Tower")]
	public float additionalGravity = 3f;

	[Header ("Minimum Velocity To Camera Shake")]
	public float minimumVelocityShake = 2f;

	[Header ("Maximum Velocity Shake Input")]
	public float maximumVelocityShake = 2f;

	[Header ("Jump Camera Shake Amounts")]
	public float magnitude = 1f;
	public float roughness = 1f;
	public float fadeInTime = .1f;
	public float fadeOutTime = 1f;

    // Use this for initialization
    void Start ()
    {
        ballRB = this.GetComponent<Rigidbody>(); //gets rigidbody
	}

    void OnCollisionEnter(Collision collision) //as long as colliding w obj, not working for now
    {
		// We need to tag all objects that are the floor to be floor, becuase if we use the root name trick, then we can climb up walls
		if(collision.gameObject.tag == "Floor")
        {
			//Debug.Log("Collision: " + collision.relativeVelocity.y);


			onGround = true;
			if (!firstCollision) {

				// using relative velocity, otherwise velocity would be zero, I guess
				if (collision.relativeVelocity.y > minimumVelocityShake) {
					CameraShaker.Instance.ShakeOnce (Mathf.Abs((collision.relativeVelocity.y > maximumVelocityShake? maximumVelocityShake:collision.relativeVelocity.y) * magnitude), roughness, fadeInTime, fadeOutTime);
				}
			
			} else {
				firstCollision = false;
			}

        }
    }
		
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetKeyDown (KeyCode.Space) && onGround) {
			//Debug.Log("Jump!");
			ballRB.AddForce (jumpForce * Vector3.up, ForceMode.Impulse);
			onGround = false;
		}


		ballRB.AddForce (Vector3.down * additionalGravity);
	}
}
