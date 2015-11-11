﻿using UnityEngine;
using System.Collections;

public class BaseCamera : MonoBehaviour {

	public GameObject character;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		CameraXFollow ();
	}

	void CameraXFollow() {
		GetComponent<Camera>().transform.position = new Vector3 (character.transform.position.x, 2.61f, -11);
	}
}
