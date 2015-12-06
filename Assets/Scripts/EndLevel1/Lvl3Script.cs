using UnityEngine;
using System.Collections;

public class Lvl3Script : MonoBehaviour {

	int balloonCounter;

	public GameObject egg;
	public GameObject character;

	bool characterFlying;

	// Use this for initialization


	void Start () {
		balloonCounter = 0;
		StartGeneratingEggs ();
	}
	
	// Update is called once per frame
	void Update () {
		characterFloat ();
	}
	

	public void IncreaseBalloonCounter(){
		balloonCounter++;
	}

	public void DecreaseBalloonCounter(){
		balloonCounter--;
	}

	void StartGeneratingEggs(){
		InvokeRepeating ("GenerateEgg", 1f, 2f);
	}
	

	void GenerateEgg(){
		if (balloonCounter > 0) {
			Instantiate (egg);
		}
	}

	void characterFloat(){
		if(balloonCounter > 0)
			character.GetComponent<Rigidbody2D>().velocity = (new Vector2(character.GetComponent<Rigidbody2D> ().velocity.x, 0.5f * balloonCounter));
	}

	

}
