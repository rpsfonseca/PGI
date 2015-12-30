using UnityEngine;
using System.Collections;

public class EndLevelColliderLvl4 : MonoBehaviour {

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
	
	void OnCollisionEnter2D(Collision2D col){
		if(col.gameObject.name.Equals("Character")){
			PlayerPrefs.SetInt("lvl5",1);
			PlayerPrefs.SetInt ("lastlevel",4);
			Application.LoadLevel(5);
		}
	}
}
