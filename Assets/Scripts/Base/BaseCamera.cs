using UnityEngine;
using System.Collections;

public class BaseCamera : MonoBehaviour {

	public GameObject character;
	public int yOffSet;
	bool mapOn = false;
	float originalSize;

	// Use this for initialization
	void Start () {
		originalSize = GetComponent<Camera> ().orthographicSize;
	}

	void FixedUpdate(){

	if (mapOn == true) {
			float xAxisValue = Input.GetAxis ("Horizontal");
			float yAxisValue = Input.GetAxis ("Vertical");


			GetComponent<Camera> ().transform.Translate (new Vector3 (xAxisValue, yAxisValue, 0.0f));
		}


	
	}
	// Update is called once per frame
	void Update () {
		CameraXFollow ();
		Mpressed ();
	}

	void CameraXFollow() {
		if (mapOn == false) {
			GetComponent<Camera> ().transform.position = new Vector3 (character.transform.position.x, character.transform.position.y + yOffSet, -11);
		}
	}

	void Mpressed(){
		if (Input.GetKeyDown (KeyCode.M) == true && mapOn == false) {
			GetComponent<Camera> ().orthographicSize = 20;
			mapOn = true;
			//Time.timeScale = 0;
		} else if(Input.GetKeyDown(KeyCode.M) == true && mapOn == true) {
			GetComponent<Camera> ().orthographicSize = originalSize;
			mapOn = false;
			//Time.timeScale = 1;
		}
	}

	public bool getMapOn(){
		return mapOn;
	}
}
