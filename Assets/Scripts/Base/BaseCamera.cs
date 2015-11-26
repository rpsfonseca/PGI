using UnityEngine;
using System.Collections;

public class BaseCamera : MonoBehaviour {

	public GameObject character;
	public int yOffSet;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		CameraXFollow ();
	}

	void CameraXFollow() {
		GetComponent<Camera>().transform.position = new Vector3 (character.transform.position.x, character.transform.position.y + yOffSet, -11);
	}
}
