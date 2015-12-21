using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HintMessage2 : MonoBehaviour {
    //
	public Text hintMessage;
	public GameObject arrow;
	public GameObject character;

	bool jumped = false;

	// Use this for initialization
	void Start () {
		arrow.GetComponentInChildren<Renderer> ().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		checkIfJumped ();
		changeHint ();
	}

	public bool getJumped(){
		return jumped;
	}

	void checkIfJumped() {
		if (character.GetComponent<CharacterMov> ().grounded == false) {
			jumped = true;
		}
	}

	void changeHint() {
		if (jumped == false) {
			hintMessage.text = "Now you must jump... Press space!";
		}
		else if(jumped == true){
			hintMessage.text = "Great! Now pass by the end level arrow!";
			arrow.GetComponentInChildren<Renderer>().enabled = true;
		}
	}
}
