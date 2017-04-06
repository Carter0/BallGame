using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlMovement : MonoBehaviour {

  	public Transform startMarker;
    public Transform endMarker;
    private Transform gameObjectMarker;
    public float speed;
    private float lerpTime;
    private float journeyLength;
    private float journeyLength2;

    private bool direction = true;

	
    void Start() {
        lerpTime = Time.time;
        journeyLength = Vector3.Distance(startMarker.position, endMarker.position);
        gameObjectMarker = this.gameObject.transform;
    }
    
    void Update() {
        
        Direction1 ();
        Direction2 ();

        //if the platform has reached the first endpoint, then make it go back to the startpoint
        //reset the lerptime so that fracjounrney can go back to being 0 so that lerping works
        if (gameObjectMarker.position == startMarker.position) {
            direction = true;
            lerpTime = Time.time;
        } else if (gameObjectMarker.position == endMarker.position) { 
            direction = false;
            lerpTime = Time.time;
        }
          
        

        
    }

    //take the platform from the startpoint to the endpoint
    void Direction1 () {
        float distCovered = (Time.time - lerpTime) * speed;
        float fracJourney = distCovered / journeyLength;
        //print ("direction1: " + fracJourney);
        if (direction == true){
            transform.position = Vector3.Lerp(startMarker.position, endMarker.position, fracJourney);
        }
    }
    
    //take the platform from the endpoint to the startpoint
    void Direction2 () {
        float distCovered = (Time.time - lerpTime) * speed;
        float fracJourney2 = distCovered / journeyLength;
       // print ("direction2: " + fracJourney2);
        if (direction == false) {
            transform.position = Vector3.Lerp(endMarker.position, startMarker.position, fracJourney2);
        }
    }
    

    void OnTriggerEnter (Collider player) {
        if(player.gameObject.tag == "Player"){
            player.transform.parent = this.transform;
         }
     }
 
    void OnTriggerExit (Collider player) {
        if (player.gameObject.tag == "Player") {
            player.transform.parent = null;      
        }
     } 

}
