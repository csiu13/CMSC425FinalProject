using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour {

	public Button b;

	// Use this for initialization
	void Start () {
		b.onClick.AddListener (StartGame);
		PlayerPrefs.DeleteAll ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void StartGame() {
		SceneManager.LoadScene ("AirTraining");
	}
}
