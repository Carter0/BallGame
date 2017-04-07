using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Movement : MonoBehaviour {

	 bool canJump = false;
	 public float speed;
     private Rigidbody rb;
	 public int jumpForceY = 0;
	 public int jumpForceX = 0;
	 public int jumpForceZ = 0;

     void Start ()
     {
         rb = GetComponent<Rigidbody>();
     }

     void FixedUpdate ()
     {
		 BallMovement ();
		 Jumping();

		 print (canJump);
		 //print (GetComponent <Rigidbody>().velocity.y);
    }

	//if the ball collides with the platform, then it can jump
	void OnCollisionEnter(Collision collision) {
		 if (collision.gameObject.tag == "Platform") {
			 canJump = true;
		 } 	 
	}
	
	//Once the ball is off the platform, it can no longer jump
	void OnCollisionExit(Collision collision) {
		canJump = false;
	}

	//function handles movement 
	//also makes sure the movement is relative to the camera
	void BallMovement () {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		movement = Camera.main.transform.TransformDirection(movement);
		movement = new Vector3 (movement.x, 0.0f, movement.z); 
		//print (movement);
		rb.AddForce (movement * speed);
		
		//print(movement * speed);
	}


	//jumping
	//Only jump the ball if canJump = true
	void Jumping () {
		if (Input.GetKeyDown (KeyCode.Space) && canJump == true){
			rb.AddRelativeForce (jumpForceX, jumpForceY, jumpForceZ);
			canJump = false;
		}	

	}


}
