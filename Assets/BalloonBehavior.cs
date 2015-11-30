using UnityEngine;
using System.Collections;

public class BalloonBehavior : MonoBehaviour {

	public Rigidbody2D character;
	Vector3 initialGrav;
	bool isFlying = false;
	public GameObject egg;

	// Use this for initialization
	void Start () {
		initialGrav = Physics2D.gravity;
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnCollisionEnter2D( Collision2D col){
		if (col.gameObject.name.Equals ("Character")) {
			Debug.Log("Entrou no collider");
			createJoint();
			if (isFlying == true) {
				StartGeneratingEggs();
			}
		}

		if (col.gameObject.name.Equals ("egg")) {
			deleteJoint();
		}
	}


	void createJoint() {
	//	GetComponent<GameObject> ().AddComponent<DistanceJoint2D> ();
	//	GetComponent<GameObject> ().GetComponent<DistanceJoint2D> ().connectedBody = character;
	//	GetComponent<GameObject> ().GetComponent<DistanceJoint2D> ().distance = 0.5f;
		Physics2D.gravity = new Vector3 (0, 0.5f, 0);
		isFlying = true;

	}

	void deleteJoint() {

	//	GetComponent<GameObject> ();
		Physics2D.gravity = initialGrav;
	}

	void StartGeneratingEggs(){
		InvokeRepeating ("GenerateEgg", 2f, 3f);
	}

	void GenerateEgg(){
		Instantiate (egg);
	}


}
