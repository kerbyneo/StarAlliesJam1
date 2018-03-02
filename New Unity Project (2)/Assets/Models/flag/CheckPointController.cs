using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointController : MonoBehaviour {


	public GameObject flag1;
	public GameObject flag2;

	private GameObject checkpoint;



	// Use this for initialization
	void Start () {

		flag1 = this.gameObject.GetComponent<Material> ();
		flag2 = this.gameObject.GetComponent<Material> ();

		checkpoint = this.gameObject;

	}
	
	// Update is called once per frame
	void Update () {





	}


	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.name == "Sphere") {
		
		
		
		
		
		
		}
	}

}
