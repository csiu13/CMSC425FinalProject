using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchOn : MonoBehaviour {

	public bool triggered = false;

	private SpriteRenderer sr;

	// Use this for initialization
	void Start () {
		sr = GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.name.Contains ("Projectile") || col.name.Contains("Player")) {
			sr.color = Color.clear;
			triggered = true;
		}
	}
}
