using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinishTextController : MonoBehaviour {

	// time count
	public Text timeCount;


	// finish texts
	public List<Text> finishTexts = new List<Text> ();

	// gameplay text
	public List<Text> gameplayTexts = new List<Text> ();

	// start menu text
	public List<Text> startTexts = new List<Text> ();




	public GameObject ballOB;


	public void showFinishUI() {

		Debug.Log ("Show finish");

		timeCount.text = (Time.time - ballOB.GetComponent<BallController>().timeStart).ToString ("0.00");

		// show the finish ui
		foreach (Text text in finishTexts) {
		
			text.gameObject.SetActive (true);
		
		}

		// hide the gameplay ui
		foreach (Text text in gameplayTexts) {

			text.gameObject.SetActive (false);

		}
	
	}


	public void hideFinishUI() {

		// hide the finish ui
		foreach (Text text in finishTexts) {

			text.gameObject.SetActive (false);

		}

		ballOB.GetComponent<BallController> ().restartGame ();

	}


	public void hideStartUI() {
	
		// hide the start ui
		foreach (Text text in startTexts) {

			text.gameObject.SetActive (false);

		}


	}

	public void showGameUI() {

		// show the game ui
		foreach (Text text in gameplayTexts) {

			text.gameObject.SetActive (true);

		}


	}

	public void restartButtonClicked() {

		Debug.Log ("Restart Button Pressed");

		hideFinishUI ();
	
	}
}
