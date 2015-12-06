using UnityEngine;
using System.Collections;

public class Lvl3Script : MonoBehaviour {

	int balloonCounter;

	public GameObject character;

	bool characterFlying;

	// Use this for initialization


	void Start () {
		balloonCounter = 0;
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log ("Number of balloons: " + balloonCounter);
	}


	public void IncreaseBalloonCounter(){
		balloonCounter++;
	}

	public void DecreaseBalloonCounter(){
		balloonCounter--;
	}

	

}
