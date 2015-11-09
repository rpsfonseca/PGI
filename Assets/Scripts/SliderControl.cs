using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SliderControl : MonoBehaviour {

	public Text timeLabel;
	public Text velocityLabel;
	public GameObject firstCheck;
	public GameObject secondCheck;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		checkSliderValue ();
	}

	void checkSliderValue() {
		velocityLabel.text = "Velocity: " + GetComponent<Slider> ().value + " m/s";
		timeLabel.text = "Time: " + (firstCheck.transform.position.x - secondCheck.transform.position.x) / GetComponent<Slider> ().value * (-1) + " s";

		
	}
}
