using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLine : MonoBehaviour {
	static public ProjectileLine S; // Singleton

	[Header("Set in Inspector")]
	public float minDist = 0.1f;

	private LineRenderer line;
	private GameObject _poi;
	private List<Vector3> points;

	void Awake() {
		S = this; // Set the singleton
		// Get a reference to the LineRenderer
		line = GetComponent<LineRenderer>();
		// Disable the LineRenderer until it is needed
		line.enabled = false;
		// Initialize the points list
		points = new List<Vector3>();
	}
	
	// This is a property (that is, a method masquerading as a field)
	public GameObject poi {
		get { return(_poi); }
		set {
			_poi = value;
			if (_poi != null) {
				// When _poi is set to something new, it resets everything
				line.enabled = false;
				points = new List<Vector3>();
				AddPoint();
			}
		}
	}
	
	// This can be used to clear the line directly
	public void Clear() {
		_poi = null;
		line.enabled = false;
		points = new List<Vector3>();
	}

	public void AddPoint() {
		
	}
	
	void FixedUpdate() {
		
	}
}
