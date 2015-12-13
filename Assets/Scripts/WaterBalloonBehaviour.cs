using UnityEngine;
using System.Collections;

public class WaterBalloonBehaviour : MonoBehaviour {

	public GameObject launcher;

	// Use this for initialization
	void Start () {
		transform.position = launcher.transform.position;

	}


	// Update is called once per frame
	void Update () {
		GetComponent<Rigidbody2D> ().velocity = new Vector2 (10, 0);
	}

	void OnCollisionEnter2D(Collision2D col){
		Debug.Log ("Destroyed");
		Destroy (this.gameObject);
		}

	}


