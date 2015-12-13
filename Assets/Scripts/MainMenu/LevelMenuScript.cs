using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelMenuScript : MonoBehaviour {

	static bool[] completedTable = new bool[3];
	static int level1 = 0;
	static int level2 = 0;
	public Sprite[] imageArray = new Sprite[3];
	public Sprite locked;



	void Start () {
		completedTable [0] = true;
		//PlayerPrefs.SetInt ("lvl2", level2);
		//level2 = PlayerPrefs.GetInt ("lvl2");

		DontDestroyOnLoad(this.gameObject);


		if (completedTable [1] == true || PlayerPrefs.HasKey("lvl2")) {
			transform.FindChild("Level2Image_btn").GetComponent<Image>().sprite = imageArray [1];
		} else {
			transform.FindChild("Level2Image_btn").GetComponent<Image>().sprite = locked;
		}

		if (completedTable [2] == true || PlayerPrefs.HasKey("lvl3")) {
			transform.FindChild("Level3Image_btn").GetComponent<Image>().sprite = imageArray [2];
		} else {
			transform.FindChild("Level3Image_btn").GetComponent<Image>().sprite = locked;
		}

	}

	public void setCompletedTableTrue(int level){
		completedTable [level - 1] = true;
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
