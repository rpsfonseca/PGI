using UnityEngine;
using System.Collections;

public class Lvl3Script : MonoBehaviour {

	int balloonCounter;

	public GameObject egg;
	public GameObject character;
	public GameObject camera;

	bool characterFlying;

	// Use this for initialization


	void Start () {
		balloonCounter = 0;
		StartGeneratingEggs ();
	}
	
	// Update is called once per frame
	void Update () {
		characterFloat ();
		moveCamera ();
	}
	

	public void IncreaseBalloonCounter(){
		balloonCounter++;
	}

	public void DecreaseBalloonCounter(){
		balloonCounter--;
	}

	void StartGeneratingEggs(){
		InvokeRepeating ("GenerateEgg", 1f, 1f);
	}
	

	void GenerateEgg(){
		if (balloonCounter > 0) {
			Instantiate (egg);
		}
	}

	public int getBalloonCounter(){
		return balloonCounter;
	}

	void characterFloat(){
		if(balloonCounter > 0)
			character.GetComponent<Rigidbody2D>().velocity = (new Vector2(character.GetComponent<Rigidbody2D> ().velocity.x, 1f * balloonCounter));
	}

	void moveCamera(){
		if (camera.GetComponent<BaseCamera> ().getMapOn() == false) {
			if (balloonCounter > 0) {
				camera.GetComponent<Camera> ().orthographicSize = 10;
			} else if (balloonCounter == 0) {
				camera.GetComponent<Camera> ().orthographicSize = 6;
			}
		}
	}

	

}
