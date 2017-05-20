using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowTip : MonoBehaviour {

	public Text tip;
	public GameObject s;
	public Color def;

	private SwitchOn so;

	// Use this for initialization
	void Start () {
		tip.color = Color.clear;
		so = s.GetComponent<SwitchOn> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(so.triggered){
			tip.color = def;
		}
	}
}
