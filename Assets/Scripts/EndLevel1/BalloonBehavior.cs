using UnityEngine;
using System.Collections;

public class BalloonBehavior : MonoBehaviour {

	public GameObject character;
	public Lvl3Script script;
	public GameObject spawnPoint;
	public Sprite[] balloonColor = new Sprite[6]; 
	public GameObject HeliumPad;

	
	bool isFlying = false;
	public GameObject egg;



	// Use this for initialization
	void Start () {
		GetComponent<SpriteRenderer> ().enabled = true;
		transform.position = spawnPoint.transform.position;
		HeliumPad.GetComponent<HeliumWorker> ().setHasBalloon (true);
		GetComponent<Rigidbody2D> ().gravityScale = 0;
		GetComponent<SpriteRenderer>().sprite = balloonColor[Random.Range(0,5)];
		GetComponent<Animator>().SetTrigger("BalloonGrow");
	}
	
	// Update is called once per frame
	void Update () {
		deleteJoint ();
		//Debug.Log (character.gameObject.name);
	}



	public void setFlying(bool value){
		isFlying = value;
	}

	void OnCollisionEnter2D( Collision2D col){
		if (col.gameObject.name.Equals ("Character")) {

			Debug.Log ("Entrou");
			createJoint ();
			//StartGeneratingEggs();
			script.IncreaseBalloonCounter ();


		} else {
			if(GetComponent<DistanceJoint2D>() == null){
				Debug.Log ("Entrou no null");
				if(this.name.Equals("balloons only_0")){
					GetComponent<SpriteRenderer>().enabled = false;
				   Debug.Log("Certo!");
				}
				else
					Destroy (this.gameObject);
			}
			else{
				Debug.Log ("Entrou no not null");
				HeliumPad.GetComponent<HeliumWorker> ().setHasBalloon (false);
				Destroy (GetComponent<DistanceJoint2D> ());
				script.DecreaseBalloonCounter();
				isFlying = false;
				if(!this.name.Equals("balloons only_0"))
					Destroy (this.gameObject);
				else{
					GetComponent<SpriteRenderer>().enabled = false;
				}
			}
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
			HeliumPad.GetComponent<HeliumWorker> ().setHasBalloon (false);
			Destroy (GetComponent<DistanceJoint2D> ());
			script.DecreaseBalloonCounter();
			isFlying = false;
		} 
	}




}
