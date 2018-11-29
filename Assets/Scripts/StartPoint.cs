using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPoint : MonoBehaviour {

	private PlayerController thePlayer; // the player object
	private CameraController theCamera; //the camera object

	public Vector2 startDirection;

	public string pointName;
	// Use this for initialization
	void Start () {
		thePlayer = FindObjectOfType<PlayerController>(); //sets thePlayer to an object which has the script "PlayerController" attached to it

		if(thePlayer.startPoint == pointName){
			thePlayer.transform.position = transform.position; //moves the player object  to the object attached to this script
			thePlayer.LastMove = startDirection;
			

			theCamera = FindObjectOfType<CameraController>();//sets theCamera to an object which has the scripts "CameraController" attached to it
			theCamera.transform.position = new Vector3(transform.position.x, transform.position.y, theCamera.transform.position.z);//moves the camera object to the object attached to this script
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
