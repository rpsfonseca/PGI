using UnityEngine;
using System.Collections;

public class Lvl3Script : MonoBehaviour {

	public GameObject balloon;

	public Animator anim;
	public GameObject heliumPad;
	public GameObject character;

	bool characterFlying;

	// Use this for initialization

	float originalX;
	float originalY;
	float originalZ;

	void Start () {

		originalX = balloon.transform.localScale.x;
		originalY = balloon.transform.localScale.y;
		originalZ = balloon.transform.localScale.z;

	}
	
	// Update is called once per frame
	void Update () {
		increaseBalloon ();
		floatInBalloon ();
	}

	void increaseBalloon(){
		if (Input.GetKeyDown (KeyCode.R) && Mathf.Abs (heliumPad.transform.position.x - character.transform.position.x) < 3) {
			anim.SetTrigger("Rpressed");
			/*if(balloon.transform.localScale.x > 4)
				balloon.transform.localScale = new Vector3(originalX,originalY,originalZ);
			else
				balloon.transform.localScale += new Vector3(1f,1f,0f); */
		}

	}



	void floatInBalloon(){
		if (Mathf.Abs (character.transform.position.x - balloon.transform.position.x) < 1) {
		}
	}

}
