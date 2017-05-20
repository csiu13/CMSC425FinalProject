using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level5 : MonoBehaviour {

	private GameObject[] locked1;
	private GameObject[] locked2;
	private GameObject[] locked3;
	private SwitchOn[] switches;
	private bool unlocked = false;

	// Use this for initialization
	void Start () {
		switches = new SwitchOn[3];
		GameObject[] sTemp = GameObject.FindGameObjectsWithTag ("Switch");
		for(int i  = 0; i < sTemp.Length; i++) {
			int index = int.Parse (sTemp [i].name.Substring (sTemp [i].name.Length - 1)) - 1;
			switches [index] = sTemp [i].GetComponent<SwitchOn> ();
			Debug.Log (sTemp [i].name);
		}

		locked1 = GameObject.FindGameObjectsWithTag ("Lock1");
		locked2 = GameObject.FindGameObjectsWithTag ("Lock2");
		locked3 = GameObject.FindGameObjectsWithTag ("Lock3");

		foreach(GameObject l in locked1) {
			l.SetActive (false);
		}
		foreach(GameObject l in locked2) {
			l.SetActive (false);
		}
		foreach(GameObject l in locked3) {
			l.SetActive (false);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (!unlocked) {
			bool lock1 = switches [0].triggered; //Top
			bool lock2 = switches [1].triggered; //Bottom
			bool lock3 = switches [2].triggered; //Side

			if (lock1 && lock2) {
				foreach (GameObject o in locked3) {
					o.SetActive (true);
				}
				unlocked = true;
			} else if (lock3 && lock2) {
				//Debug.Log ("heh");
				foreach (GameObject o in locked1) {
					o.SetActive (true);
				}
				unlocked = true;
			} else if (lock1 && lock3) {
				foreach (GameObject o in locked2) {
					o.SetActive (true);
				}
				unlocked = true;
			}
		}
	}
}
