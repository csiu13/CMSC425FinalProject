using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ReachGoal : MonoBehaviour {

	public int level;
	public SpriteRenderer goal;
	public string element;
	public bool setButtons = true;

	private GameObject[] switches;
	private GameObject results;
	// Use this for initialization
	void Start () {
		goal = GetComponent<SpriteRenderer> ();
		if (level > 0) {
			goal.color = Color.clear;
		}
		switches = GameObject.FindGameObjectsWithTag ("Switch");

		if (setButtons) {
			results = GameObject.FindGameObjectWithTag ("Result");
			Button[] buttons = results.GetComponentsInChildren<Button> ();
			buttons [0].onClick.AddListener (RetryOnClick);
			buttons [1].onClick.AddListener (NextOnClick);
			//Debug.Log (buttons[0].name + " " + buttons[1].name);
			results.SetActive (false);
		}
	}

	// Update is called once per frame
	void Update () {
		for (int i = 0; i < switches.Length; i++) {
			if (!switches [i].GetComponent<SwitchOn> ().triggered) {
				break;
			}
			if (i == switches.Length - 1) {
				goal.color = Color.white;
			}
		}
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (goal.color != Color.clear && col.name.Contains("Player")) {
			if (level > 0) {
				results.SetActive (true);
				Time.timeScale = 0;
				GameObject.Find ("Timer").SendMessage("EndTimer", level);
			} else if (element == "") {
				SceneManager.LoadScene ("Level1");
			} else {
				SceneManager.LoadScene (element + "Training");
			}
		}
	}

	void NextOnClick() {
		level++;
		if (level == 8) {
			SceneManager.LoadScene ("GameFinished");
			Time.timeScale = 1;
		} else {
			string name = "Level" + level.ToString ();
			SceneManager.LoadScene (name);
			Time.timeScale = 1;
		}
	}

	void RetryOnClick() {
		SceneManager.LoadScene (SceneManager.GetActiveScene().name);
		Time.timeScale = 1;
	}
}
