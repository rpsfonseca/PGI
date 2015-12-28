using UnityEngine;
using System.Collections;

public class BaseCamera : MonoBehaviour {

	public GameObject character;
	public int yOffSet;
	bool mapOn = false;
	float originalSize;

	public Transform firstWall;
	public Transform LastWall;

	bool stopCam = false;

	//float max;
	//float min;

	// Use this for initialization
	void Start () {
		Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Character"),
		                               LayerMask.NameToLayer("Camera"),
		                               true
		                               );
		originalSize = GetComponent<Camera> ().orthographicSize;
		//GetComponent<BoxCollider2D> ().size = new Vector2 (GetComponent<Camera> ().WorldToViewportPoint(transform.position).x, GetComponent<Camera> (transform.position).WorldToViewportPoint().y);
		GetComponent<BoxCollider2D> ().size = new Vector2 (GetComponent<Camera> ().orthographicSize * 3, GetComponent<Camera> ().orthographicSize * 2);

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

	void OnTriggerEnter2D(Collider2D col){
		Debug.Log (col.name);
		if (col.gameObject.name.Equals (firstWall.name)) {
			Debug.Log ("entrou no cam collider");
			// || col.gameObject.name.Equals(LastWall.name)) {
			Debug.Log ("pos a true");
			stopCam = true;
		}

	}
	void OnTriggerExit2D(Collider2D col){
		if (col.gameObject.name.Equals (firstWall.name)) {
			Debug.Log ("ola");
			stopCam = false;
		}
	}

	void CameraXFollow() {
		if (mapOn == false) {
		//	if(character.transform.position.x > min && character.transform.position.x < max){
			if(stopCam == false){
			GetComponent<Camera> ().transform.position = new Vector3 (character.transform.position.x, character.transform.position.y + yOffSet, -11);
			}
	//		}
			else{
				Debug.Log ("O stopcam esta  true");
				GetComponent<Camera> ().transform.position = new Vector3 (GetComponent<Camera>().transform.position.x, character.transform.position.y + yOffSet, -11);
			}
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
