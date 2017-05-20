using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class General : MonoBehaviour {

	public GameObject projectile;

	private GameObject lossScreen;
	private Move player;

	// Use this for initialization
	void Start () {
		lossScreen = GameObject.FindGameObjectWithTag ("Loss");
		lossScreen.SetActive (false);

		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Move> ();

		//projectile.SetActive (false);
		Physics2D.IgnoreCollision (player.GetComponent<Collider2D> (), projectile.GetComponent<Collider2D> ());
	}
	
	// Update is called once per frame
	void Update () {
		if (!player.alive) {
			Time.timeScale = 0;
			lossScreen.SetActive (true);
		}

		if(Input.GetKeyDown("r")) {
			SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
			Time.timeScale = 1;
		}

		if (Input.GetKeyDown ("q")) {
			Application.Quit ();
		}

	}
}
