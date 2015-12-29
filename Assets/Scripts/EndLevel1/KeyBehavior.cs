using UnityEngine;
using System.Collections;

public class KeyBehavior : MonoBehaviour {

	bool colected = false;

	// Use this for initialization
	void Start () {
		colected = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public bool getColected(){
		return colected;
	}

	void OnTriggerEnter2D(Collider2D col){
		if(col.gameObject.name.Equals("Character")){
			Debug.Log ("Passou chave");
			colected = true;
			GetComponent<SpriteRenderer>().enabled = false;
		}
	}
}
