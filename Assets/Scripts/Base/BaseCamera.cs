using UnityEngine;
using System.Collections;

public class BaseCamera : MonoBehaviour {

	public GameObject character;
	public int yOffSet;
	bool mapOn = false;
	float originalSize;

	//public Transform firstWall;
	//public Transform LastWall;

	//float max;
	//float min;

	// Use this for initialization
	void Start () {
		originalSize = GetComponent<Camera> ().orthographicSize;

	//	min = firstWall.position.x + 7.5f;
	//	max = LastWall.position.x - 7.5f;
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
		//	if(character.transform.position.x > min && character.transform.position.x < max){
			
			GetComponent<Camera> ().transform.position = new Vector3 (character.transform.position.x, character.transform.position.y + yOffSet, -11);
	//		}
	//		else{
	//			GetComponent<Camera> ().transform.position = new Vector3 (GetComponent<Camera>().transform.position.x, character.transform.position.y + yOffSet, -11);
	//		}
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
