using UnityEngine;
using System.Collections;

public class EndLevelCollider2 : MonoBehaviour {


	public SpeechBallonBehavior script;
	public int levelToLoad = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(){
		if(script.getFinished() == true){
			PlayerPrefs.SetInt("lvl3",1);
			PlayerPrefs.SetInt ("lastlevel",2);
			Application.LoadLevel(3);
		}
	}
}
