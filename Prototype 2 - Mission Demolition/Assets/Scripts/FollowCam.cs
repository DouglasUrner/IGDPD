using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour {
	static public GameObject POI; // The static point of interest

	[Header("Set in Inspector")]
	public float easing = 0.05f;
	public Vector2 minXY = Vector2.zero;

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
		// Limit the X & Y to minimum values
		destination.x = Mathf.Max(minXY.x, destination.x);
		destination.y = Mathf.Max(minXY.y, destination.y);
		// Interpolate from the current Camera position toward the destination
		destination = Vector3.Lerp(transform.position, destination, easing);
		// Force destination.z to be the camZ to keep the camera far enough away
		destination.z = camZ;
		// Set the camera to the destination
		transform.position = destination;
	}
}
