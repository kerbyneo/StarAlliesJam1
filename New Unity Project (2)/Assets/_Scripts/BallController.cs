using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class BallController : MonoBehaviour {
    
	private Rigidbody ballRB;
    private bool onGround;
    public float jumpForce = 1.0f;
	private bool firstCollision = true;

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
			//Debug.Log("Collision");

			onGround = true;
			if (!firstCollision) {
				CameraShaker.Instance.ShakeOnce (magnitude, roughness, fadeInTime, fadeOutTime);
			} else {
				firstCollision = false;
			}

        }
    }
		
	void OnCollisionExit(Collision collision) {

		if (collision.gameObject.tag == "Floor") {
			//Debug.Log("Collision");

			onGround = false;
		}
	}
		
	
	// Update is called once per frame
	void FixedUpdate () {
		if(Input.GetKeyDown(KeyCode.Space) && onGround)
        {
           	//Debug.Log("Jump!");
			ballRB.AddForce(jumpForce * Vector3.up, ForceMode.Impulse);
        }
	}
}
