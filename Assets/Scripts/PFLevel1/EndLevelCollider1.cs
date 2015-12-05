using UnityEngine;
using System.Collections;

public class EndLevelCollider1 : MonoBehaviour {
		
	public GameObject script;
	public int levelToLoad = 0;
	bool isCompleted = false;
	// Use this for initialization
	void Start () {
	}
		
	// Update is called once per frame
	void Update () {
			
	}
		
	void OnCollisionEnter2D(){
		if(script.GetComponent<HintMessage1> ().getValid()){

			Application.LoadLevel(levelToLoad);
		}
	}
}