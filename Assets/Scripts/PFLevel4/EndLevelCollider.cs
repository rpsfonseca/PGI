using UnityEngine;
using System.Collections;

public class EndLevelCollider : MonoBehaviour {
	
	public int levelToLoad = 0;
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
