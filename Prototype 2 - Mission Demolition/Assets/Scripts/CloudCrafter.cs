using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudCrafter : MonoBehaviour {
	[Header("Set in Inspector")]
	public int numClouds = 40;          // The # of clouds to make
	public GameObject cloudPrefab;      // The prefab for the clouds
	public Vector3 cloudPosMin = new Vector3(-50, -5, 10);
	public Vector3 cloudPosMax = new Vector3(150, 100, 10);
	public float cloudScaleMin = 1;     // Min scale on each cloud
	public float cloudScaleMax = 3;     // Max scale on each cloud
	public float cloudSpeedMult = 0.5f; // Adjusts the speed of clouds

	private GameObject[] cloudInstances;

	void Awake() {
		
	}
	
	void Update() {
		
	}
}
