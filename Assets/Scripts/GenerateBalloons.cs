using UnityEngine;
using System.Collections;

public class GenerateBalloons : MonoBehaviour {

	public GameObject balloon;

	// Use this for initialization
	void Start () {
		StartGeneratingEggs ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void StartGeneratingEggs(){
		InvokeRepeating ("GenerateBalloon", 1f, 2f);
	}
	
	
	void GenerateBalloon(){
		Instantiate (balloon);
	}



}
