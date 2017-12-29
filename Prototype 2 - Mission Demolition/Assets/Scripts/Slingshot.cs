using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slingshot : MonoBehaviour {
	public GameObject launchPoint;

	void Awake() {
		Transform launchPointTrans = transform.Find("LaunchPoint");
		launchPoint = launchPointTrans.gameObject;
		launchPoint.SetActive(false);
	}

	void OnMouseEnter() {
		// print("Slingshot:OnMouseEnter()");
		launchPoint.SetActive(true);
	}
	
	void OnMouseExit() {
		// print("Slingshot:OnMouseExit()");
		launchPoint.SetActive(false);
	}
}
