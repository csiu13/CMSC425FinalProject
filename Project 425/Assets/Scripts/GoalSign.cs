using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalSign : MonoBehaviour {

	private GameObject gsign;
	private ReachGoal goal;
	// Use this for initialization
	void Start () {
		gsign = GameObject.FindGameObjectWithTag ("GoalSign");
		gsign.SetActive (false);
		goal = GameObject.FindGameObjectWithTag ("Goal").GetComponent<ReachGoal> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (goal.goal.color == Color.white) {
			gsign.SetActive (true);
		}
	}
}
