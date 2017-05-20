using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {

	public float move = 150;
	public float jump = 10000;
	public bool alive = true;
	public Vector2 dir = Vector2.right;
	public GameObject projectile;
	public float gravScale = 500;

	private int jumps = 2;
	private Rigidbody2D rb;
	private SpriteRenderer sr;
	private int mode = 2;
	private GameObject player;
	private Vector2 gravDir = Vector2.down;
	private bool onWall = false;
	private float shrinkScale = .25f;
	private Vector3 defScale = new Vector3 (20, 20, 1);

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		sr = GetComponent<SpriteRenderer> ();
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {

		//Horizontal movment
		float horMove = Input.GetAxis("Horizontal");
		float scale = mode == 1 ? 0.75f : 1;
		if (horMove > 0.2) {
			if (gravDir != Vector2.right && gravDir != Vector2.left) {
				rb.AddForce (new Vector2 (move, 0) * scale) ;
				dir = Vector2.right;
			}
		} else if (horMove < -0.2) {
			if (gravDir != Vector2.right && gravDir != Vector2.left) {
				rb.AddForce (new Vector2 (-move, 0) * scale) ;
				dir = Vector2.left;
			}
		}

		//Pressing "Up"
		if (Input.GetKeyDown ("up") && jumps > 0 && mode == 2) {
			rb.AddForce (new Vector2 (0, jump) * scale);
			jumps--;
		}

		float lsx = rb.transform.localScale.x;
		float lsy = rb.transform.localScale.y;

		//Hold down "Up"
		if (Input.GetKey("up")) {
			if (mode == 1) {
				rb.AddForce (new Vector2 (0, move) * scale);
			} else if(mode == 3 && gravDir != Vector2.down) {
				rb.AddForce (new Vector2 (0, move) * scale * 2);
			} else if (mode == 4 && lsx < 30) {
				rb.transform.localScale = new Vector3 (lsx + shrinkScale, lsy + shrinkScale, rb.transform.localScale.z);
				//Debug.Log (rb.transform.localScale);
			}
		}

		//Hold down "Down"
		if (Input.GetKey("down")) {
			if (mode == 1) {
				rb.AddForce (new Vector2 (0, -move) * scale);
			} else if (mode == 3 && gravDir != Vector2.up) {
				rb.AddForce (new Vector2 (0, -move) * scale * 2);
			} else if (mode == 4 && lsx > 10) {
				rb.transform.localScale = new Vector3 (lsx - shrinkScale, lsy - shrinkScale, rb.transform.localScale.z);
			}
		}

		//Changing modes
		Vector2 vel = rb.velocity;
		if (Input.GetKeyDown ("a")) {
			sr.color = Color.white;
			rb.gravityScale = 0.5f;
			rb.drag = .5f;
			rb.transform.localScale = defScale;
			gravDir = Vector2.down;
			mode = 1;
		} else if (Input.GetKeyDown ("s")) {
			sr.color = Color.red;
			rb.gravityScale = 10;
			rb.drag = .5f;
			rb.transform.localScale = defScale;
			gravDir = Vector2.down;
			mode = 2;
		} else if (Input.GetKeyDown ("d") && mode != 3) {
			sr.color = Color.black;
			rb.gravityScale = 0;
			rb.drag = .5f;
			rb.transform.localScale = defScale;
			gravDir = Vector2.down;
			mode = 3;
		} else if (Input.GetKeyDown ("f")) {
			sr.color = Color.blue;
			rb.gravityScale = 10;
			rb.drag = .25f;
			gravDir = Vector2.down;
			mode = 4;
		}

		//Pressing "space"
		if (Input.GetKeyDown ("space")) {
			if (mode == 2) {
				Vector3 pos = player.transform.position;
				//Debug.Log (pos);
				Quaternion angle = Quaternion.Euler (0, 0, 90);
				//Debug.Log (pos);
				if (dir == Vector2.right) {
					pos.x += 1f;
					angle = Quaternion.Euler (0, 0, 270);
				} else {
					pos.x -= 1f;
				}

				Instantiate (projectile, pos, angle);
			}
		}

		//Hold down "space"
		if (Input.GetKey("space") && mode == 3) {
			if (Input.GetKeyDown ("up")) {
				gravDir = Vector2.up;
			} else if(Input.GetKeyDown("left")) {
				gravDir = Vector2.left;
			} else if(Input.GetKeyDown("right")) {
				gravDir = Vector2.right;
			} else if(Input.GetKeyDown("down")) {
				gravDir = Vector2.down;
			}
			onWall = false;
		}

		//Earth mode gravity
		if (mode == 3 && !onWall) {
			rb.AddForce (gravDir * gravScale);
			//Debug.Log (gravScale);
		}
	}

	void OnCollisionEnter2D(Collision2D col) {
		string name = col.collider.name;
		if (mode != 4) {
			if (name.Contains ("Ground") || name.Contains("Platform")) {
				jumps = 2;
				onWall = true;
			} else if (name.Contains ("Spike")) {
				alive = false;
			}
		} else if (name.Contains ("Wall") && mode == 3) {
			onWall = true;
		}
	}

	void OnCollisionExit2D(Collision2D col) {
		onWall = false;
	}
}
