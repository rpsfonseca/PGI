using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HintMessage1 : MonoBehaviour {

	public Text hintText;
	bool movedLeft = false, movedRight = false;
	float deadZone = 0.02f; //Margin for sensitive analog inputs
	float inputHorizontal;
	public GameObject arrow;
	bool valid = false;
		
	void Start() {
		arrow.GetComponentInChildren<Renderer> ().enabled = false;
	}
	

	
	// Update is called once per frame
	void Update () {
		checkMovement ();
		changeHint ();
	}

	void checkMovement(){
		inputHorizontal = Input.GetAxis ("Horizontal");
		if (inputHorizontal < -deadZone) {
			movedLeft = true;
		}
		if (inputHorizontal > deadZone) {
			movedRight = true;
		}
	}

	void changeHint() {
		if (movedLeft == false && movedRight == false) {
			hintText.text = "Use A to move to the left and D \nto move to the right!";
		} else if (movedLeft == true && movedRight == false) {
			hintText.text = "Great! Now go to the right by pressing D!";
		} else if (movedLeft == false && movedRight == true) {
			hintText.text = "Great! Now go to the left by pressing A!";
		} else if (movedLeft == true && movedRight == true) {
			hintText.text = "Good! Now you got it! Pass the sign with the \narrow  to go to the next level!";
			arrow.GetComponentInChildren<Renderer>().enabled = true;
			valid = true;
		}
		                                                  
	}

	public bool getValid(){
		return(valid);
	}
}
