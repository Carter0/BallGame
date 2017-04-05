using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour {
	
	//I think I need a coroutine

	private float dist;

	public Transform target;
	public GameObject bulletPrefab;

	public int rocketFireDelay = 5;


	void Start () {
		StartCoroutine(FireRocket (rocketFireDelay));
	}
    
    void Update() {
		LookAt ();
	}

	//Rotates turret towards player
	void LookAt () {
		transform.LookAt(target);
	}

	//fires the bullet
	IEnumerator FireRocket (int wait) {
		while (true) {
			//print ("fire a bullet");
			//casting my instantiated bullet as a GameObject
			//this means I can access the properties of the object specific to gameobjects
			GameObject bullet = (GameObject) Instantiate (bulletPrefab, transform.position, transform.rotation);
			bullet.GetComponent <BulletController>().WakeUp (this.transform, target);								
			yield return new WaitForSeconds(wait);
		}
		
		
	}
    
}
