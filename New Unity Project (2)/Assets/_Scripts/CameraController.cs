using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {


	[Header ("Camera Position Offset is set to transform location")]
	[Space]
	public Vector3 cameraLookOffset = new Vector3(0F,.9F,0F);
	[Header ("Time to reach, larger is longer")]
	public float cameraSpeed = 1;


	private Vector3 cameraPositionOffset;


	private GameObject towerGO;
	private float startTime;


	// Use this for initialization
	void Start () {


		towerGO = GameObject.Find ("CanonTower_Modified");

		cameraPositionOffset = this.transform.position - towerGO.transform.position;
		startTime = Time.time;


	}
	
	// Update is called once per frame
	void FixedUpdate () {

		//Debug.DrawLine (this.transform.position, this.transform.position + this.transform.forward);

		//Debug.DrawLine (towerGO.transform.position, towerGO.transform.position + cameraLookOffset);

		Vector3 targetLocation = towerGO.transform.position + cameraPositionOffset;

		float fracComplete = (Time.time - startTime) / cameraSpeed;
		this.transform.position = Vector3.Slerp (this.transform.position, targetLocation, fracComplete);


		this.transform.LookAt (towerGO.transform.position + cameraLookOffset);
	}




}
