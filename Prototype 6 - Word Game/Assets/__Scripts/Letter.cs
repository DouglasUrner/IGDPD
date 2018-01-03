using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering;

public class Letter : MonoBehaviour {
	[Header("Set Dynamically")]
	public TextMesh tMesh; // The TextMesh shows the character

	public Renderer tRend; // The Renderer of 3D Text. This will determine

	// whether the char is visible
	public bool big = false; // Big letters act a little differently

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
		set { transform.position = value; }
	}
}
