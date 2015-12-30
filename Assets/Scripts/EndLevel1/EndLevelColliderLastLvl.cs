using UnityEngine;
using System.Collections;

public class EndLevelColliderLastLvl : MonoBehaviour {

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
			PlayerPrefs.SetInt("lvl7",1);
			PlayerPrefs.SetInt ("lastlevel",8);
			Application.LoadLevel(8);
		}
	}
}
