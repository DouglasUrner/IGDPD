using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering;

public class Letter : MonoBehaviour {
	[Header("Set in Inspector")]
	public float timeDuration = 0.5f;
	public string easingCurve = Easing.InOut;
	
	[Header("Set Dynamically")]
	public TextMesh tMesh; // The TextMesh shows the character

	public Renderer tRend; // The Renderer of 3D Text. This will determine

	// whether the char is visible
	public bool big = false; // Big letters act a little differently
	// Linear interpolation fields
	public List<Vector3> pts = null;
	public float timeStart = -1;

	private char _c; // The char shown on this letter
	private Renderer rend;

	void Awake() {
		tMesh = GetComponentInChildren<TextMesh>();
		tRend = tMesh.GetComponent<Renderer>();
		rend = GetComponent<Renderer>();
		visible = false;
	}

	// Property to get or set _c and the letter shown by 3D Text
	public char c {
		get { return _c; }
		set {
			_c = value;
			tMesh.text = _c.ToString();
		}
	}

	public string str {
		get { return _c.ToString(); }
		set { c = value[0]; }
	}

	public bool visible {
		get { return tRend.enabled; }
		set { tRend.enabled = value; }
	}

	public Color color {
		get { return (rend.material.color); }
		set { rend.material.color = value; }
	}

	public Vector3 pos {
		set {
			// transform.position = value;
			Vector3 mid = (transform.position + value) / 2f;
			float mag = (transform.position - value).magnitude;
			mid += Random.insideUnitSphere * mag * 0.25f;
			pts = new List<Vector3>() {transform.position, mid, value};
			if (timeStart == -1) timeStart = Time.time;
		}
	}
	
	// Moves immediately to the new position
	public Vector3 posImediate {
		set { transform.position = value; }
	}
	
	// Interpolation code
	private void Update() {
		if (timeStart == -1) return;
		
		// Standard linear interpolation code
		float u = (Time.time - timeStart) / timeDuration;
		u = Mathf.Clamp01(u);
		float u1 = Easing.Ease(u, easingCurve);
		Vector3 v = Utils.Bezier(u1, pts);
		transform.position = v;
		// If the interpolation is done, set timeStart back to -1
		if (u == 1) timeStart = -1;
	}
}
