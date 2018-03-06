using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWalkway : MonoBehaviour {

	public float moveSpeed = 10f;
	double x;
	double y;
	int blah = 1;


	void Update (){
		x = transform.position.x;
		y = transform.position.y;

		if(blah ==1){
		transform.Translate (Vector3.forward * moveSpeed * Time.deltaTime);
			if(x<-215){
				blah = 2;
			}
		
		}

		if(blah ==2){
			transform.Translate (Vector3.back * moveSpeed * Time.deltaTime);
			if(x>-174){
				blah = 1;
			}
		}

}
}

