using UnityEngine;
using System.Collections;

public class EndLevelCollider1 : MonoBehaviour {
		
	public SpeechBallonBehavior script;
	//LevelMenuScript lvlMenuScripts;
	public int levelToLoad = 0;
	bool isCompleted = false;
	// Use this for initialization
	void Start () {

	}
		
	// Update is called once per frame
	void Update () {
			
	}
		
	void OnCollisionEnter2D(){
		if(script.getFinished()){
			PlayerPrefs.SetInt("lvl2",1);
			PlayerPrefs.SetInt ("lastlevel",1);
			Application.LoadLevel(2);
		}
	}
}