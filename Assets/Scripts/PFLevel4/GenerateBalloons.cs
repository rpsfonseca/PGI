using UnityEngine;
using System.Collections;

public class GenerateBalloons : MonoBehaviour {

	public GameObject balloon;
    //this should be working while poof isn't hitted
    private static bool working;
    private float timeBetweenLaunches;
    private float timePassedAfterLaunch;
	// Use this for initialization
	void Start () {
        working = true;
		//StartGeneratingEggs ();
        timeBetweenLaunches = 0.5f;
        timePassedAfterLaunch = 0;
	}
	
	// Update is called once per frame
	void Update () {
        timePassedAfterLaunch += Time.deltaTime;
        if(timePassedAfterLaunch > timeBetweenLaunches)
        {
            timePassedAfterLaunch = 0;
            GenerateBalloon();
        }
	}


	void StartGeneratingEggs(){
		InvokeRepeating ("GenerateBalloon", 1f, 2f);
	}
	
	
	void GenerateBalloon(){
        if (working)
        {
            Instantiate(balloon);
        }
	}

    public void setWorking(bool val)
    {
        working = val;
    }
}
