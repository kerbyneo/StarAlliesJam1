﻿using System.Collections;
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
	
		float tempTime = Time.time;

		while (Time.time - tempTime < fadeTime && fadeTime > 0) {
		
			imageBlack.color.a = ((Time.time - tempTime) / fadeTime);
		
		
		}


		ballController.RespawnAll ();


		while (Time.time - tempTime < fadeTime && fadeTime > 0) {

			imageBlack.color.a = (1 - ((Time.time - tempTime) / fadeTime));


		}
	
	
	
	}


}
