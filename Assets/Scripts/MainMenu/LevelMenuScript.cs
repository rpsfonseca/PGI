using UnityEngine;
using System.Collections;

public class LevelMenuScript : MonoBehaviour {



	void Start () {
	}
	

	public void LevelOnePressed() {
		Application.LoadLevel (1);
	}

	public void LevelTwoPressed() {
		Application.LoadLevel (2);
	}

	public void LevelThreePressed() {
		Application.LoadLevel (3);
	}
	                               

}
