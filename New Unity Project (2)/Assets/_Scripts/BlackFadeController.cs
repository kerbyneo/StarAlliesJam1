using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlackFadeController : MonoBehaviour {

	private Image imageBlack;



	public GameObject ballGO;

	private BallController ballController;


	public float fadeTime = .6f;

	// Use this for initialization
	void Start () {

		imageBlack = this.GetComponent<Image> ();

		ballController = ballGO.GetComponent<BallController> ();
		
	}
	
	public IEnumerator fadeBlackRespawn() {

		//Debug.Log ("IEnumerator called");
	
		float tempTime = Time.time;

		while (Time.time - tempTime < fadeTime && fadeTime > 0) {

			//Debug.Log ((Time.time - tempTime) / fadeTime);
		
			imageBlack.color = new Color(imageBlack.color.r, imageBlack.color.g, imageBlack.color.b, ((Time.time - tempTime) / fadeTime));
		
			yield return null;
		}


		//Debug.Log ("Respawn Called");

		ballController.RespawnAll ();


		tempTime = Time.time;
		while (Time.time - tempTime < fadeTime && fadeTime > 0) {

			//Debug.Log (1 - ((Time.time - tempTime) / fadeTime));

			imageBlack.color = new Color(imageBlack.color.r, imageBlack.color.g, imageBlack.color.b, 1 - ((Time.time - tempTime) / fadeTime));

			yield return null;
		}
	
	
	}


}
