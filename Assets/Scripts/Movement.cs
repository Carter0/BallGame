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

     //Note to self: rb.addforce functions belong in update, not fixedupdate. 
     void Update ()
     {
		 BallMovement ();
		 Jumping();
		 //print (canJump);

     }

	//if the ball collides with the platform, then it can jump
	void OnCollisionStay(Collision collision) {
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
        rb.AddForce (movement * speed, ForceMode.Acceleration);
	}


	//jumping
	//Only jump the ball if canJump = true
	void Jumping () {
		if (Input.GetKeyDown (KeyCode.Space) && canJump == true){
            rb.AddForce (jumpForceX, jumpForceY, jumpForceZ);
            canJump = false;
		}


    }




}



