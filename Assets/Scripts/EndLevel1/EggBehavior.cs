using UnityEngine;
using System.Collections;

public class EggBehavior : MonoBehaviour {

	public GameObject character;
	float randomness = 10;
	public GameObject script;

	// Use this for initialization
	void Start () {
		transform.position = new Vector3 (transform.position.x + ( randomness * Random.value) , character.transform.position.y + 10, transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D( Collision2D col){
		Debug.Log ("Entrou no collider");
		if (col.gameObject.name.Equals ("Character")) {
			script.GetComponent<BalloonBehavior> ().setFlying (false);
		} else if(!this.name.Equals("Egg")) {
			Destroy(this.gameObject);
		}
	}
}
