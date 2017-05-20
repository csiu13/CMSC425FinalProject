using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndScreen : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameObject.Find ("Timer").SendMessage("EndTimer", 8);
		GameObject.Find ("Quit").GetComponent<Button> ().onClick.AddListener (Quit);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void Quit() {
		Application.Quit ();
	}
}
