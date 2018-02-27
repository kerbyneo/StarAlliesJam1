using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {
    private Rigidbody ballRB;
    public Text gameOverText;
    public GameObject archers;
    public Archers_CountController archerScript;

	// Use this for initialization
	void Start () {
        ballRB = this.GetComponent<Rigidbody>();
        archers = GameObject.Find("Archers_Count");
        archerScript = archers.GetComponent<Archers_CountController>(); //accessing script
    }
    
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Water") //if tower or sphere collides with water
        {
            //Debug.Log("Water");
            gameOverText.text = "Game Over";
        }
    }

    // Update is called once per frame
    void FixedUpdate () {
        if(archerScript.archerCount == 0) //if all archers fall off
        {
            gameOverText.text = "Game Over";
        }
	}
}
