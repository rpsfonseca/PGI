using UnityEngine;
using System.Collections;

public class FinishWallCollider : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.name == "Character") {
			Debug.Log ("Deteta");
			if(Application.loadedLevel == 0)
				Application.LoadLevel(1);
			else if(Application.loadedLevel == 1)
				Application.LoadLevel(0);
		}
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
