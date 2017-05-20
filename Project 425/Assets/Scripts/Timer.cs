using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

	public Text timerText;
	public Text timer;
	public bool gover = false;

	//private float[] bests = new float[7];
	private float start;
	private float currTime;

	// Use this for initialization
	void Start () {
		start = Time.time;
	}

	// Update is called once per frame
	void Update () {
		currTime = Time.time - start;
		timerText.text = TimeToString(currTime);
	}

	string TimeToString(float time) {
		int min = (int)time / 60;
		float sec = (time % 60);

		string m = min < 10 ? "0" + min.ToString () : min.ToString ();
		string s = sec < 10 ? "0" + sec.ToString ("f2") : sec.ToString ("f2");
		return m + ":" + s;
	}

	void EndTimer(int level) {
		for (int i = 1; i < level; i++) {
			Text b = GameObject.Find (i + "/Best").GetComponent<Text> ();
			b.text = TimeToString (PlayerPrefs.GetFloat(i+""));
		}

		if (!gover) {
			Text c = GameObject.Find (level + "/Current").GetComponent<Text> ();
			c.text = timerText.text;

			float currBest = PlayerPrefs.GetFloat (level + "");
			if (currBest == 0 || currBest > currTime) {
				PlayerPrefs.SetFloat (level + "", currTime);
				currBest = currTime;
			}
			Text best = GameObject.Find (level + "/Best").GetComponent<Text> ();
			best.text = TimeToString (currBest);
		}
	}
}
