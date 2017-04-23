using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyhit : MonoBehaviour {

    public Transform respawnpoint;
    GameObject restart;

    void Awake()
    {
        restart = GameObject.FindGameObjectWithTag("RestartButton");
        restart.SetActive (false);
    }


    //destroys the gameobject that hs been collided with
    void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.CompareTag ("Bullet")) {
			//print ("collision has occured");
			Destroy (collision.gameObject);
			gameObject.SetActive (false);
            ActivateRestartButton();
        } 		
	}

    //Activate the restart button
    void ActivateRestartButton () {
        restart.SetActive (true);
    }

    //Respawn the player if the restart button is pressed
    public void Respawn() {
        this.transform.position = respawnpoint.position;
        gameObject.SetActive(true);
        restart.SetActive(false);
    }

}
