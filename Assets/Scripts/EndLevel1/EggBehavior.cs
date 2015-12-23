using UnityEngine;
using System.Collections;

public class EggBehavior : MonoBehaviour {

	public GameObject character;
	public GameObject leftWall;
	public GameObject rightWall;


	
	float randomness;


	// Use this for initialization
	void Start () {
		randomness = rightWall.transform.position.x - leftWall.transform.position.x;
		transform.position = new Vector3 (rightWall.transform.position.x - ( randomness * Random.value) , character.transform.position.y + 10, transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D( Collision2D col){
		Debug.Log ("Entrou no collider");
		if (!this.name.Equals ("Egg")) {
			Destroy(this.gameObject);
		}else if(col.gameObject.name.Equals("firstBalloon")){
			Debug.Log ("BAteu num balao");
		}

		//if (col.gameObject.name.Equals ("Character")) {
		//	script.GetComponent<BalloonBehavior> ().setFlying (false);
		//} else if(!this.name.Equals("Egg")) {
		//	Destroy(this.gameObject);
		//}
	}
}
