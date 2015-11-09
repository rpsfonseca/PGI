﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CheckPointCollider : MonoBehaviour {

	public Text counter;
	public Text status;

	private bool firstPassed = false, secondPassed = false;
	float timePassed = 0;

	void OnTriggerEnter2D(Collider2D col) {
		if (col.name.Equals ("FirstCheck") && firstPassed == false) {
			Debug.Log ("Passed first cp");
			firstPassed = true;
		} else if (col.name.Equals ("SecondCheck") && secondPassed == false) {
			Debug.Log ("Passed second cp: passed in:  " + timePassed);
			statusText();
			secondPassed = true;
		}
	}

	
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		countTime ();
	}

	void countTime() {
		if (firstPassed == true && secondPassed == false) {
			timePassed += Time.deltaTime;
			counter.text = "Counter: " + timePassed;
		}
	}

	void statusText(){
		if (timePassed <= 1.1f && timePassed >= 0.95f) {
			status.text = "Sucess";
			status.color = new Color (45f, 225f, 22f,255f);
			status.gameObject.SetActive (true);
		} else {
			status.text = "Failure";
			status.color = new Color(251f,0f,30f,255f);
			status.gameObject.SetActive (true);
		}
	}
}
