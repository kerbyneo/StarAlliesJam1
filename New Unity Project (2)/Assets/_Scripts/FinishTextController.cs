using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinishTextController : MonoBehaviour {

	// time count
	public Text timeCount;


	// finish texts
	public List<Text> finishTexts = new List<Text> ();

	public Text winText;
	public Text timeText;

	public Text restartText;
	public Button restartButton;

	// gameplay text
	public List<Text> gameplayTexts = new List<Text> ();



	public GameObject ballOB;


	public void showFinish() {

		timeCount.text = (Time.time - ballOB.GetComponent<BallController>().timeStart).ToString ();

		// show the finish ui
		foreach (Text text in finishTexts) {
		
			text.gameObject.SetActive (true);
		
		}

		// hide the gameplay ui
		foreach (Text text in gameplayTexts) {

			text.gameObject.SetActive (false);

		}
	
	}


	public void hideFinish() {

		// hide the finish ui
		foreach (Text text in finishTexts) {

			text.gameObject.SetActive (false);

		}

		// show the gameplay ui
		foreach (Text text in gameplayTexts) {

			text.gameObject.SetActive (true);

		}


		ballOB.GetComponent<BallController> ().restartGame ();

	}


	public void ButtonClicked() {

		hideFinish ();
	
	}
}
