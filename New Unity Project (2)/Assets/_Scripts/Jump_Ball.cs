using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump_Ball : MonoBehaviour {
    private Rigidbody ballRB;
    private bool onGround;
    private Vector3 jump;
    public float jumpForce = 1.0f;

    // Use this for initialization
    void Start ()
    {
        ballRB = this.GetComponent<Rigidbody>(); //gets rigidbody
        jump = new Vector3(0, 1f, 0);
	}

    void onCollisionStay(Collision coll) //as long as colliding w obj, not working for now
    {
        if(coll.gameObject.tag == "Floor")
        {
            onGround = true;
            Debug.Log("Collision");
        }
    }
	
	// Update is called once per frame
	void FixedUpdate () {
		if(Input.GetKey(KeyCode.Space))
        {
            Debug.Log("Jump!");
            ballRB.AddForce(jump * jumpForce, ForceMode.Impulse);
            onGround = false;
        }
	}
}
