using UnityEngine;
using System.Collections;

public class DoorBehavior : MonoBehaviour {

	public KeyBehavior key;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D col){
		if(col.gameObject.name.Equals("Character")){
			if(key.getColected() == true){
				Destroy (this.gameObject);
			}
		}
	}
}
