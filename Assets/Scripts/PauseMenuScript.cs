using UnityEngine;
using System.Collections;

public class PauseMenuScript : MonoBehaviour {

	bool isPaused = false;
	public GameObject pausePanel;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		CheckIfEscPressed ();
	}

	void CheckIfEscPressed(){
		if (Input.GetKeyDown (KeyCode.Escape) || Input.GetKeyDown (KeyCode.P)) {
			if(isPaused == false){
				PauseGame();
			}
			else{
				ResumePressed();
			}
		}
	}

	void PauseGame(){
		pausePanel.SetActive(true);
		isPaused = true;
		Time.timeScale = 0;
	}

	public void ResumePressed(){
		pausePanel.SetActive(false);
		isPaused = false;
		Time.timeScale = 1;

	}

	public void RestartPressed() {
		Application.LoadLevel (Application.loadedLevel);
		Time.timeScale = 1;
	}
	

	public void OptionPressed() {
		//WIP
	}

	public void MainMenuPressed() {
		//Need confirmation panel here
		Application.LoadLevel (0);
	}

	public void ExitPressed() {

		//Need confirmation panel here
		Application.Quit ();
	}
}
