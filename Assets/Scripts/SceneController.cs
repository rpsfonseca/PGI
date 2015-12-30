using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SceneController : MonoBehaviour {
    int levelToLoad;
    public Text infoText;
    RectTransform text;

    // Use this for initialization
    void Start () {
        levelToLoad = PlayerPrefs.GetInt("lastlevel");
    }
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ButtonDoAction(){
		if (levelToLoad == 7)
			Application.LoadLevel (0);
		Application.LoadLevel (levelToLoad + 1);
	}
}
