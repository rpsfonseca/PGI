using UnityEngine;
using System.Collections;

public class CheckPointCollider : MonoBehaviour {

	private bool firstPassed = false, secondPassed = false;

	void OnTriggerEnter2D(Collider2D col) {
		if (col.name.Equals ("FirstCheck") && firstPassed == false) {
			Debug.Log ("Passed first cp");
			firstPassed = true;
		} else if (col.name.Equals ("SecondCheck") && secondPassed == false) {
			Debug.Log ("Passed second cp");
			secondPassed = true;
		}
	}

	
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
