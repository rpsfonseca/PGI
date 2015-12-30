using UnityEngine;
using System.Collections;

public class CrateScript : MonoBehaviour {

	public GameObject balloon;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		turnKinematic ();
	
	}

	void OnCollisionEnter2D(Collision2D col){
        if (col.gameObject.tag == "WaterBallon"){
            this.GetComponent<Rigidbody2D>().isKinematic = true;
		}
	}

	void turnKinematic(){
		if (this.GetComponent<Rigidbody2D> ().isKinematic == true) {
			this.GetComponent<Rigidbody2D> ().isKinematic = false;
		}
	}
}
