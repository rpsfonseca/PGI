using UnityEngine;
using System.Collections;

public class BalloonBehavior : MonoBehaviour {

	public GameObject character;
	Vector3 initialGrav;
	bool isFlying = false;
	public GameObject egg;


	// Use this for initialization
	void Start () {
		initialGrav = Physics2D.gravity;
	}
	
	// Update is called once per frame
	void Update () {
		if (isFlying == true) {
			character.GetComponent<Rigidbody2D> ().velocity = new Vector2(0,2);
		}
	}

	public void setFlying(bool value){
		isFlying = value;
	}
	
	void OnCollisionEnter2D( Collision2D col){
		if (col.gameObject.name.Equals ("Character")) {
			Debug.Log("Entrou no collider");
			createJoint();
			isFlying = true;
			StartGeneratingEggs();

		}

		if (col.gameObject.name.Equals ("egg")) {
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

	//	GetComponent<GameObject> ();
	//	Physics2D.gravity = initialGrav;
	}

	void StartGeneratingEggs(){
			InvokeRepeating ("GenerateEgg", 1f, 2f);
	}

	void GenerateEgg(){
		if (isFlying == true) {
			Instantiate (egg);
		}
	}


}
