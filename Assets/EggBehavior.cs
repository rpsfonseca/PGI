using UnityEngine;
using System.Collections;

public class EggBehavior : MonoBehaviour {

	public GameObject character;

	// Use this for initialization
	void Start () {
		transform.position = new Vector3 (character.transform.position.x + 2 , character.transform.position.y + 6, character.transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
