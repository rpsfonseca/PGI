using UnityEngine;
using System.Collections;

public class Ladder : MonoBehaviour {

	public GameObject character;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		//checkIfInRange ();
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.name.Equals ("Character")) {
			character.GetComponent<CharacterMov> ().setIsLadder (true);
            character.GetComponent<CharacterMov>().ladderCollider = this.GetComponent<BoxCollider2D>();
            character.GetComponent<Animator>().SetBool("Climb", true);
            Debug.Log ("entrou");
		}
	}

	void OnTriggerExit2D(Collider2D col) {
		if (col.gameObject.name.Equals ("Character")) {
			character.GetComponent<CharacterMov> ().setIsLadder (false);
            character.GetComponent<CharacterMov>().ladderCollider = this.GetComponent<BoxCollider2D>();
            character.GetComponent<Animator>().SetBool("Climb", false);
            Debug.Log ("saiu");
		}
	
	}

	/*void checkIfInRange(){
		if (Mathf.Abs (character.transform.position.x - GetComponent<GameObject> ().transform.position.x) <= 1) {
			character.GetComponent<CharacterMov> ().setIsLadder (true);
		} else {
			character.GetComponent<CharacterMov>().setIsLadder(false);
		}
	} */
}
