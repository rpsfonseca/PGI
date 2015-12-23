using UnityEngine;
using System.Collections;

public class BalloonBehavior : MonoBehaviour {

	public GameObject character;
	public Lvl3Script script;

	
	bool isFlying = false;
	public GameObject egg;



	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

	}



	public void setFlying(bool value){
		isFlying = value;
	}
	
	void OnCollisionEnter2D( Collision2D col){
		if (col.gameObject.name.Equals ("Character")) {
			createJoint();
			//StartGeneratingEggs();
			script.IncreaseBalloonCounter();


		}

		if (col.gameObject.name.Equals ("egg") || Input.GetKeyDown(KeyCode.Space)) {
			deleteJoint();
		}
	}


	void createJoint() {


		gameObject.AddComponent<DistanceJoint2D> ();
		GetComponent<DistanceJoint2D> ().connectedBody = character.GetComponent<Rigidbody2D> ();
		GetComponent<DistanceJoint2D> ().distance = 0;
		GetComponent<Rigidbody2D> ().gravityScale = -0.2f;
		GetComponent<DistanceJoint2D> ().anchor = new Vector2 (0, -2);


		isFlying = true;

	}

	void deleteJoint() {
		deleteJoint ();
	}




}
