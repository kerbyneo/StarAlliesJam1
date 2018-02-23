using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour {

	private Text textF;

	// Use this for initialization
	void Start () {
		textF = this.GetComponent<Text> ();

	}
	
	// Update is called once per frame
	void Update () {

		int archerCount = 0;

		if (!GameObject.Find ("Archer").GetComponent<ArcherController> ().touchedGround) {
		
			archerCount++;

		}

		if (GameObject.Find ("Archer (1)").GetComponent<ArcherController> ().touchedGround) {

			archerCount++;

		}

		if (GameObject.Find ("Archer (2)").GetComponent<ArcherController> ().touchedGround) {

			archerCount++;


		}


		textF.text = archerCount.ToString ();

	}
}
