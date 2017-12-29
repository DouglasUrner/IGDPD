using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidbodySleep : MonoBehaviour {
	void Start () {
		Rigidbody rb = GetComponent<Rigidbody>();
		if (rb != null) rb.Sleep();
	}
}
