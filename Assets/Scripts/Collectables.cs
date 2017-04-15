using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Collectables : MonoBehaviour {

    public int collectableCount = 0;
    public Text collectableCountText;
    

 	//if the player collides with the collectable,
	//make the collectable inactive and run CollectableCount
	void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag ("collectable")){
            other.gameObject.SetActive (false);
            CollectableCount ();
        }
    }

  

    //sets the number of collectables collected and displays them on the screen
    void CollectableCount () {
        //print ("running");
        collectableCount ++;
        collectableCountText.text = "Collectables Found: " + collectableCount;
    }
}
