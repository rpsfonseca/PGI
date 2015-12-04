using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelMenuScript : MonoBehaviour {

	bool[] completedTable;
	public Sprite[] imageArray = new Sprite[3];
	public Sprite locked;


	void Start () {
		completedTable = new bool[3];
		completedTable [0] = true;


		if (completedTable [1] == true) {
			transform.FindChild("Level2Image_btn").GetComponent<Image>().sprite = imageArray [1];
		} else {
			transform.FindChild("Level2Image_btn").GetComponent<Image>().sprite = locked;
		}

		if (completedTable [2] == true) {
			transform.FindChild("Level3Image_btn").GetComponent<Image>().sprite = imageArray [2];
		} else {
			transform.FindChild("Level3Image_btn").GetComponent<Image>().sprite = locked;
		}

	}
	

	public void LevelOnePressed() {

		if (completedTable [0] == true) {
			Application.LoadLevel (1);
		} 
	}

	public void LevelTwoPressed() {
		Application.LoadLevel (2);
	}

	public void LevelThreePressed() {
		Application.LoadLevel (3);
	}
	                               

}
