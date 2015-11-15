using UnityEngine;
using System.Collections;

public class LevelMenuScript : MonoBehaviour {

	public Canvas mainMenu;

	void Start () {
		
		mainMenu = mainMenu.GetComponent<Canvas> ();
		
	}

	public void backPressed() {
		GetComponent<Canvas> ().gameObject.SetActive (false);
		mainMenu.gameObject.SetActive (true);
	}

	public void LevelOnePressed() {
		Application.LoadLevel (1);
	}

	public void LevelTwoPressed() {
		Application.LoadLevel (2);
	}

}
