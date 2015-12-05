using UnityEngine;
using System.Collections;

public class HeliumWorker : MonoBehaviour {

	public GameObject balloon;
	public GameObject character;
	public Sprite[] balloonColor = new Sprite[6];

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		growBalloon ();
	}

	void growBalloon(){
		if (Input.GetKeyDown (KeyCode.R) && Mathf.Abs (transform.position.x - character.transform.position.x) < 3 && balloon.transform.localScale.x == 0) {
			balloon.GetComponent<SpriteRenderer>().sprite = balloonColor[Random.Range(0,5)];
			balloon.GetComponent<Animator>().SetTrigger("BalloonGrow");

		}
		
	}

}
