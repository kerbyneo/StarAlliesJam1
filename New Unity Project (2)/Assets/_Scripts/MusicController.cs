using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MusicController : MonoBehaviour {


	private bool playingMusic = true;

	public AudioSource music;

	public GameObject ballOB;
	public GameObject musicTextObject;

	// Use this for initialization
	void Start () {


		music = this.GetComponent<AudioSource> ();

		playMusic (true);

	}


	public void playMusic() 
	{
	
	
		if (playingMusic) {
		
		
			playMusic (false);
		
		} else {
		
			playMusic (true);
		
		}
	
	}
	
	public void playMusic(bool doMusic)
	{
	
		if (doMusic) {
			ballOB.GetComponent<BallController>().playMusic = true;
			music.Play ();
			playingMusic = true;
			musicTextObject.GetComponent<Text> ().text = "Music On";

		} else {
			ballOB.GetComponent<BallController>().playMusic = false;
			music.Pause ();
			playingMusic = false;

			musicTextObject.GetComponent<Text> ().text = "Music Off";
		}
	
	}
}
