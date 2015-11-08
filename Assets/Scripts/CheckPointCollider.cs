using UnityEngine;
using System.Collections;

public class CheckPointCollider : MonoBehaviour {

	public Collider2D firstCheck;
	public Collider2D secondCheck;


	void OnTriggerEnter() {
		Debug.Log ("Entrou");
	}

	
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
