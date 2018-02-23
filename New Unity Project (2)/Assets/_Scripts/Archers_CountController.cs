using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Archers_CountController : MonoBehaviour {

	private Text textF;
	public int archerCount = 3;

	// Use this for initialization
	void Start () {
		textF = this.GetComponent<Text> ();

	}
	
	// Update is called once per frame
	void Update () {


		textF.text = archerCount.ToString ();

	}
}
