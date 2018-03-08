using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class BallController : MonoBehaviour {


    private AudioSource source;
    public AudioClip thudSound;

	public bool DO_INPUT = true;


	private Rigidbody ballRB;
	public GameObject tower;
    private bool onGround;
    public float jumpForce = 1.0f;
	private bool firstCollision = true;
	private Vector3 origionalSpawn;


	public float respawnWait = 1.2f;
	private float timer = 0;

	public float ballTorqueAmount = 42.35f;

	public GameObject overrideSpawn;

	[Header ("Additional Gravity to Make up for Upward Force on Tower")]
	public float additionalGravity = 3f;

	[Header ("Minimum Velocity To Camera Shake")]
	public float minimumVelocityShake = 2f;

	[Header ("Maximum Velocity Shake Input")]
	public float maximumVelocityShake = 2f;

	[Header ("Jump Camera Shake Amounts")]
	public float magnitude = 1f;
	public float magnitudeExponent = 2f;
	public float roughness = 1f;
	public float fadeInTime = .1f;
	public float fadeOutTime = 1f;

	public float timeStart;


	public BlackFadeController blackFadeOB;

	public Vector3 spawnPos;

	public GameObject archerCounter;

	public List<GameObject> RESET_OBJECTS = new List<GameObject> ();


	public void restartGame() {
	
		spawnPos = origionalSpawn;
		DO_INPUT = true;
		timer = respawnWait;


		timeStart = Time.time;


	}



	void Awake () {
	
		origionalSpawn = this.transform.position;
	
	}

    // Use this for initialization
    void Start ()
    {
		timer = respawnWait;
        ballRB = this.GetComponent<Rigidbody>(); //gets rigidbody
		spawnPos = this.transform.position;

        source = GetComponent<AudioSource>();


		timeStart = Time.time;

		// edge case if the user puts in new spawn for testing
		if (overrideSpawn != null)  {
			Debug.Log ("spawn overridden");
			overrideSpawn.GetComponent<CheckPointController> ().capturePoint();
			this.RespawnAll ();
		}
	}

    void OnCollisionEnter(Collision collision) //as long as colliding w obj, not working for now
    {
		//Debug.Log (collision.gameObject.tag.ToString ());

		// We need to tag all objects that are the floor to be floor, becuase if we use the root name trick, then we can climb up walls


		if (collision.gameObject.tag == "Wood") {
		
			onGround = true;
            source.PlayOneShot(thudSound, 1F);
		
		}



		if(collision.gameObject.tag == "Floor")
		{
			//Debug.Log("Collision: " + collision.relativeVelocity.y);


			onGround = true;
            source.PlayOneShot(thudSound, 1F);

            // dont do camera shake on first collision
            if (!firstCollision) {


				//Debug.Log ("Shook camera");

				// using relative velocity, otherwise velocity would be zero, I guess





				if (collision.relativeVelocity.y > minimumVelocityShake) {

					float calculatedMagnitude = Mathf.Pow (((collision.relativeVelocity.y > maximumVelocityShake ? maximumVelocityShake : collision.relativeVelocity.y) * magnitude), magnitudeExponent);

					Debug.Log(calculatedMagnitude);

					CameraShaker.Instance.ShakeOnce (calculatedMagnitude, roughness, fadeInTime, fadeOutTime);
				}
			
			} else {
				firstCollision = false;
			}

        }
    }
		
	
	// Update is called once per frame
	void FixedUpdate () {

		if (!DO_INPUT) {
			return;
		}




		if (Input.GetKeyDown (KeyCode.Space) && onGround) {
			//Debug.Log("Jump!");
			ballRB.AddForce (jumpForce * Vector3.up, ForceMode.Impulse);
			onGround = false;
		}


		ballRB.AddForce (Vector3.down * additionalGravity);


		// get player input, apply torque relative to the ball
		if (Input.GetKey (KeyCode.W)) {

			//Debug.Log("Forward Torque Added");
			ballRB.AddTorque (Vector3.forward * ballTorqueAmount);
		}

		if (Input.GetKey (KeyCode.D)) {
			//Debug.Log("Right Torque Added");
			ballRB.AddTorque (Vector3.right * ballTorqueAmount);
		}

		if (Input.GetKey (KeyCode.S)) {
			//Debug.Log("Left Torque Added");
			ballRB.AddTorque (Vector3.forward * ballTorqueAmount * -1);
		}
		if (Input.GetKey (KeyCode.A)) {
			//Debug.Log("Backward Torque Added");
			ballRB.AddTorque (Vector3.right * ballTorqueAmount * -1);
		}






		if (archerCounter.GetComponent<Archers_CountController> ().archerCount == 0) {
			
			timer -= Time.deltaTime;


			if (timer < 0) {
			
				timer = respawnWait;
				StartCoroutine(blackFadeOB.GetComponent<BlackFadeController> ().fadeBlackRespawn ());
			}
		}
	}



	public void RespawnAll() {
	

		timer = respawnWait;

		ballRB.velocity = Vector3.zero;
		ballRB.angularVelocity = Vector3.zero;


		tower.GetComponent<Rigidbody> ().velocity = Vector3.zero;
		tower.GetComponent<Rigidbody> ().angularVelocity = Vector3.zero;



		this.transform.position = spawnPos;
		this.transform.rotation = Quaternion.identity;

		tower.transform.position = spawnPos;
		tower.transform.rotation = Quaternion.identity;

		if (RESET_OBJECTS == null) {
		
			return;
		
		}


		foreach (GameObject Gobject in RESET_OBJECTS) {
			Gobject.BroadcastMessage ("Respawn");

		}
	
	}
}
