using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableRotate : MonoBehaviour {

	GameObject collectable;

	void Start () {
		collectable = this.gameObject;
	}
	
	//Rotate the collectable to the right
	//I think this is a good use of fixedupdate?
	void FixedUpdate () {
		collectable.transform.Rotate(Vector3.right * Time.deltaTime);
	}
}
