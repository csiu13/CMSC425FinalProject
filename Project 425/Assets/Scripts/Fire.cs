using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour {

	public float speed = 1000;

	private Rigidbody2D rb;
	private GameObject player;
	private Move playerScript;
	private bool moving = false;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		rb.gravityScale = 0;
		player = GameObject.FindGameObjectWithTag ("Player");
		playerScript = player.GetComponent<Move> ();
		Physics2D.IgnoreCollision (player.GetComponent<Collider2D> (), GetComponent<Collider2D> ());
	}
	
	// Update is called once per frame
	void Update () {
		if (!moving) {
			rb.AddForce (playerScript.dir * speed);
			moving = true;
		}
	}

	void OnCollisionEnter2D(Collision2D col) {
		Destroy (rb.gameObject);
	}
}
