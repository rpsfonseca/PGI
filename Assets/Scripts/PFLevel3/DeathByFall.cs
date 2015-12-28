using UnityEngine;
using System.Collections;

public class DeathByFall : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D col){
        Debug.Log("aiai");
		if (col.gameObject.name.Equals ("Character")) {
            col.gameObject.GetComponent<CharacterMov>().setDead();
            col.gameObject.GetComponent<CharacterMov>().setDeadByFall();
            GetComponent<BoxCollider2D>().enabled = false;
        }
	}
}
