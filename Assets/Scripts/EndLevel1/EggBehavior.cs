using UnityEngine;
using System.Collections;

public class EggBehavior : MonoBehaviour {

	GameObject character;
	public GameObject leftWall;
	public GameObject rightWall;
	public GameObject balloon;


	
	float randomness;


	// Use this for initialization
	
	void Start () {
		character = GameObject.Find ("Character");

		randomness = rightWall.transform.position.x - leftWall.transform.position.x;
		transform.position = new Vector3 (rightWall.transform.position.x - ( randomness * Random.value) , character.transform.position.y + 13, transform.position.z);

	}
	
	// Update is called once per frame
	void Update () {
		Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Egg"),
		                               LayerMask.NameToLayer("GreenPlatform"),
		                               true
		                               );
	}

	void OnCollisionEnter2D( Collision2D col){
		if (!this.name.Equals ("Egg")) {
			Destroy(this.gameObject);
		}else if(col.gameObject.Equals(balloon)){
		}

		//if (col.gameObject.name.Equals ("Character")) {
		//	script.GetComponent<BalloonBehavior> ().setFlying (false);
		//} else if(!this.name.Equals("Egg")) {
		//	Destroy(this.gameObject);
		//}
	}
}
