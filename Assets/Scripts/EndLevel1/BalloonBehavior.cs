using UnityEngine;
using System.Collections;

public class BalloonBehavior : MonoBehaviour {

	public GameObject character;
	public Lvl3Script script;
	public GameObject spawnPoint;
	public Sprite[] balloonColor = new Sprite[6]; 

	
	bool isFlying = false;
	public GameObject egg;



	// Use this for initialization
	void Start () {
		transform.position = spawnPoint.transform.position;
		GetComponent<SpriteRenderer>().sprite = balloonColor[Random.Range(0,5)];
		GetComponent<Animator>().SetTrigger("BalloonGrow");
	}
	
	// Update is called once per frame
	void Update () {
		deleteJoint ();
		Debug.Log (character.gameObject.name);
	}



	public void setFlying(bool value){
		isFlying = value;
	}

	void OnCollisionEnter2D( Collision2D col){
		if (col.gameObject.name.Equals(character)){
			Debug.Log ("Entrou");
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
