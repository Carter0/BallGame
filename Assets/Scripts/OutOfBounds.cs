using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBounds : MonoBehaviour {

	public Transform respawnpoint;



	//destroys the player if the player collides with the boundary
	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.tag == "Boundary"){
			this.transform.position = respawnpoint.position;	
		}
		if (collision.gameObject.name == "RespawnPlatform") {
			respawnpoint = GameObject.FindWithTag ("RespawnB").transform;
		}
	}


}
