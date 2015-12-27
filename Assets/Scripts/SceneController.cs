using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SceneController : MonoBehaviour {
    int levelToLoad;
    public Text infoText;

    // Use this for initialization
    void Start () {
        levelToLoad = PlayerPrefs.GetInt("lastlevel") + 1;
        ChangeInfo(levelToLoad);

    }
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ButtonDoAction(){
		if (levelToLoad == 7)
			Application.LoadLevel (0);
		Application.LoadLevel (levelToLoad);
	}

    public void ChangeInfo(int lvl) {
        /*if (lvl == 1) {
            infoText.text = "Use A to move to the left and D \nto move to the right!";
        }
        else if (lvl == 2) {
            infoText.text = "Great! Now go to the right by pressing D!";
        }
        else if (lvl == 3) {
            infoText.text = "Great! Now go to the left by pressing A!";
        }
        else if (lvl == 4) {
            infoText.text = "Good! Now you got it! Pass the sign with the \narrow  to go to the next level!";
        }*/
        infoText.text = "*PLACEHOLDER, WAITING FOR TEXTS*";
    }
}
