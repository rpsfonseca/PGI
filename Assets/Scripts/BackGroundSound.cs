using UnityEngine;
using System.Collections;

public class BackGroundSound : MonoBehaviour {

	// Use this for initialization
	void Start () {

		GetComponent<AudioSource> ().pitch = (Random.Range (0.8f, 2f));

	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
