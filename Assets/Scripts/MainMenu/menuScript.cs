using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class menuScript : MonoBehaviour {

	public Canvas quitMenu;
	public Button startText;
	public Button exitText;



	void Start () {
	
		quitMenu = quitMenu.GetComponent<Canvas> ();
		startText = startText.GetComponent<Button> ();
		exitText = exitText.GetComponent<Button> ();
		quitMenu.enabled = false;

	}

	public void ExitPressed(){
		quitMenu.enabled = true;
		startText.enabled = false;
		exitText.enabled = false;
	}

	public void NoPressed() {
		quitMenu.enabled = false;
		startText.enabled = true;
		exitText.enabled = true;
	}

	public void ExitGame() {
		Application.Quit ();
	}

	public void StartLevel() {
		print ("Started game");
		Application.LoadLevel (1);
		  
	}

	public void ResetPlayerPrefs(){
		PlayerPrefs.DeleteAll ();
	}


}
