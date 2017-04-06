using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBounds : MonoBehaviour {



	//destroys the player if the player collides with the boundary
	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.tag == "Boundary"){
			gameObject.SetActive (false);	
		}
	}


}
