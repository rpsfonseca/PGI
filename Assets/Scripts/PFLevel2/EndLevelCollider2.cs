﻿using UnityEngine;
using System.Collections;

public class EndLevelCollider2 : MonoBehaviour {


	public GameObject script;
	public int levelToLoad = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(){
		if(script.GetComponent<HintMessage2>	().getJumped() == true){
					Application.LoadLevel(levelToLoad);
		}
	}
}
