using UnityEngine;
using System.Collections;

public class EndLevelColliderLvl3 : MonoBehaviour {

	public int levelToLoad = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.name.Equals ("Character")) {
			PlayerPrefs.SetInt("lvl4",1);
			PlayerPrefs.SetInt ("lastlevel",3);
			Application.LoadLevel(4);
		}
	}
}
