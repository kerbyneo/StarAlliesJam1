using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinishTextController : MonoBehaviour {


	public Text winText;
	public Text timeText;
	public Text timeCount;
	public Text restartText;
	public Button restartButton;

	public GameObject ballOB;


	public void showFinish() {

		timeCount.text = (Time.time - ballOB.GetComponent<BallController>().timeStart).ToString ();

		winText.gameObject.SetActive (true);
		timeText.gameObject.SetActive (true);
		timeCount.gameObject.SetActive (true);
		restartText.gameObject.SetActive (true);
	
	}


	public void hideFinish() {

		winText.gameObject.SetActive (false);
		timeText.gameObject.SetActive (false);
		timeCount.gameObject.SetActive (false);
		restartText.gameObject.SetActive (false);


		ballOB.GetComponent<BallController> ().restartGame ();

	}


	public void ButtonClicked() {

		hideFinish ();
	
	}
}
