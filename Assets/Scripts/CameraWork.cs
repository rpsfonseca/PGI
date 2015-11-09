using UnityEngine;
using System.Collections;

public class CameraWork : MonoBehaviour {

	public GameObject character;

	void LateUpdate(){

		stopCameraAtEdge ();
	}
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {


	}

	void stopCameraAtEdge(){
		if (character.transform.position.x <= -4.02f) {
			GetComponent<Camera> ().transform.position = new Vector3 (-4.02f, 2.61f, -1);
		} 
		else if(character.transform.position.x >= 22.18) {
			GetComponent<Camera> ().transform.position = new Vector3 (22.18f, 2.61f, -1);
		}
		else {
			GetComponent<Camera>().transform.position = new Vector3 (character.transform.position.x, 2.61f, -1);
		}
	}
}
