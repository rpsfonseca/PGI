using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GravityChanger : MonoBehaviour {

	public Slider gravSlider;
	public Text gravityValue; 

	// Use this for initialization

	void Start () {
	

	}
	
	// Update is called once per frame
	void Update () {
		sliderCheck ();
	}

	void sliderCheck(){
		Physics2D.gravity = new Vector3 (0, -gravSlider.value, 0);
		gravityValue.text = "Grav value: " + gravSlider.value;
	}
}
