using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyhit : MonoBehaviour {

	//destroys the gameobject that hs been collided with
	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.CompareTag ("Bullet")) {
			print ("collision has occured");
			Destroy (collision.gameObject);
			Destroy (this.gameObject); 
		 } 		
	}

}
