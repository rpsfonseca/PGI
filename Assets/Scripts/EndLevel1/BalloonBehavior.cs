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
		deleteJoint ();
	}



	public void setFlying(bool value){
		isFlying = value;
	}
	
	void OnCollisionEnter2D( Collision2D col){
		Debug.Log ("Nome " + col.gameObject.name);
		if (col.gameObject.name.Equals ("Character")) {
			createJoint();
			//StartGeneratingEggs();
			script.IncreaseBalloonCounter();


		}

		if (col.gameObject.name.Equals ("egg")) {
			Debug.Log ("Entrou no delete");
			Destroy (GetComponent<DistanceJoint2D> ());
			script.DecreaseBalloonCounter();
			//isFlying = false;
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
		if (Input.GetKeyDown (KeyCode.Space)  && isFlying == true ) {
			Debug.Log ("Entrou no delete");
			Destroy (GetComponent<DistanceJoint2D> ());
			script.DecreaseBalloonCounter();
			isFlying = false;
		} 
	}




}
