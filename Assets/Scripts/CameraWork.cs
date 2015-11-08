using UnityEngine;
using System.Collections;

public class CameraWork : MonoBehaviour {

	public GameObject character;

	void LateUpdate(){

		stopCameraLeftEdge ();
	}
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {


	}

	void stopCameraLeftEdge(){
		if (character.transform.position.x <= -4.02f) {
			GetComponent<Camera> ().transform.position = new Vector3 (-4.02f, 2.61f, -1);
		} else {
			GetComponent<Camera>().transform.position = new Vector3 (character.transform.position.x, 2.61f, -1);
		}
	}
}
