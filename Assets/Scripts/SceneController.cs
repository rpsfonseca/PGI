using UnityEngine;
using System.Collections;

public class SceneController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ButtonDoAction(){
		int levelToLoad = PlayerPrefs.GetInt ("lastlevel") + 1;
		if (levelToLoad == 7)
			Application.LoadLevel (0);
		Application.LoadLevel (levelToLoad);
	}
}
