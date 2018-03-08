using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Time_CountController : MonoBehaviour {


	private Text timeCount;

	public GameObject ballOB;

	// Use this for initialization
	void Start () {
		timeCount = this.GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {

		float tempTime = (Time.time - ballOB.GetComponent<BallController> ().timeStart);


		if (!ballOB.GetComponent<BallController> ().hasInputted) {
		
			tempTime = 0;
		
		}

		timeCount.text = tempTime.ToString ("0.00");

	}
}
