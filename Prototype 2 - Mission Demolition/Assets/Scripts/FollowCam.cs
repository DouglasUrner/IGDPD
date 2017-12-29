using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour {
	static public GameObject POI; // The static point of interest

	[Header("Set dynamically")]
	public float camZ; // The desired Z pos of the camera

	void Awake () {
		camZ = this.transform.position.z;
	}
	
	void FixedUpdate () {
		// if there is only one line following an if, it doesn't need braces
		if (POI == null) return;
		
		// Get the position of the poi
		Vector3 destination = POI.transform.position;
		// Force destination.z to be the camZ to keep the camera far enough away
		destination.z = camZ;
		// Set the camera to the destination
		transform.position = destination;
	}
}
