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

		DontDestroyOnLoad (this.gameObject);
	}

	void Update(){

		if (PlayerPrefs.HasKey("lvl2")) {
			transform.FindChild("Level2Image_btn").GetComponent<Image>().sprite = imageArray [1];
		} else {
			transform.FindChild("Level2Image_btn").GetComponent<Image>().sprite = locked;
		}

		if (PlayerPrefs.HasKey("lvl3")) {
			transform.FindChild("Level3Image_btn").GetComponent<Image>().sprite = imageArray [2];
		} else {
			transform.FindChild("Level3Image_btn").GetComponent<Image>().sprite = locked;
		}

		if (PlayerPrefs.HasKey("lvl4")) {
			transform.FindChild("Level4Image_btn").GetComponent<Image>().sprite = imageArray [3];
		} else {
			transform.FindChild("Level4Image_btn").GetComponent<Image>().sprite = locked;
		}

		if (PlayerPrefs.HasKey("lvl5")) {
			transform.FindChild("Level5Image_btn").GetComponent<Image>().sprite = imageArray [4];
		} else {
			transform.FindChild("Level5Image_btn").GetComponent<Image>().sprite = locked;
		}

		if (PlayerPrefs.HasKey("lvl6")) {
			transform.FindChild("Level6Image_btn").GetComponent<Image>().sprite = imageArray [5];
		} else {
			transform.FindChild("Level6Image_btn").GetComponent<Image>().sprite = locked;
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
		if(PlayerPrefs.HasKey("lvl2"))
			Application.LoadLevel (2);
	}

	public void LevelThreePressed() {
		if(PlayerPrefs.HasKey("lvl3"))
			Application.LoadLevel (3);
	}

	public void LevelFourPressed() {
		if(PlayerPrefs.HasKey("lvl4"))
			Application.LoadLevel (4);
	}

	public void LevelFivePressed() {
		if(PlayerPrefs.HasKey("lvl5"))
			Application.LoadLevel (5);
	}

	public void LevelSixPressed() {
		if(PlayerPrefs.HasKey("lvl6"))
			Application.LoadLevel (6);
	}
	                               

}
