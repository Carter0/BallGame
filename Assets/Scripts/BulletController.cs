﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

    private Vector3 startMarker;
    private Vector3 endMarker;
    public float timeToDestroy;
    public float speed = 1.0F;
    private float startTime;
    private float journeyLength;
    private Vector3 distanceVector;

    private float timeAtStart;


    //I also need to change my planes to boxes so that collision can work


    //WakeUp is a constructor
    //I call this function from my TurretController script
    public void WakeUp (Transform start, Transform end) {
        startMarker = start.position;
        endMarker = end.position;
        startTime = Time.time;
        journeyLength = Vector3.Distance(startMarker, endMarker);
        distanceVector = (endMarker - startMarker);
        distanceVector.Normalize ();

        timeAtStart = Time.time;
        


    }

    //Move the bullet towards the player by the normalized vector
    void Update () {
        float distCovered = (Time.time - startTime) * speed;
        float fracJourney = distCovered / journeyLength;
        transform.position += distanceVector * speed;

        TimeToDestroy ();
    }

    //If the bullet collides with anything, destroy the bullet
    void OnCollisionEnter (Collision other) {
        //print ("collision has occured");
        if (other.gameObject.tag == "Platform") {
            Destroy (this.gameObject);
        }
    }

    //destroys the bullet after a certain amount of time
    void TimeToDestroy () {
        //destroy the bullet if the current time is greater than the time at the creation of the bullet + the time to destroy
        if (Time.time > timeAtStart + timeToDestroy){
            Destroy (this.gameObject);
        }
    }
}