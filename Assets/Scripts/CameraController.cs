using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

     public float turnSpeed = 4.0f;
     public Transform player;
     public int cameraOffsetZ;
     public int cameraOffsetY;
 
     private Vector3 offset;
 
     void Start () {
         offset = new Vector3(player.position.x, player.position.y + cameraOffsetY, player.position.z + cameraOffsetZ);
     }
 
     void LateUpdate()
     {
         offset = Quaternion.AngleAxis (Input.GetAxis("Mouse X") * turnSpeed, Vector3.up) * offset;
         transform.position = player.position + offset; 
         transform.LookAt(player.position);
     } 
}

