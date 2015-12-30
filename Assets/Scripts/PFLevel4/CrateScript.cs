using UnityEngine;
using System.Collections;

public class CrateScript : MonoBehaviour {

	public GameObject balloon;
    private bool hitByOneWaterBallon;
    private bool hitOnTopPlatform;
	// Use this for initialization
	void Start () {
        hitByOneWaterBallon = false;
        hitOnTopPlatform = false;
    }
	
	// Update is called once per frame
	void Update () {
		turnKinematic ();
	
	}

	void OnCollisionEnter2D(Collision2D col){
        if (col.gameObject.tag == "WaterBallon" && hitOnTopPlatform == false){
            hitByOneWaterBallon = true;
            //this.GetComponent<Rigidbody2D>().isKinematic = true;
		}
        else if(hitByOneWaterBallon == true && col.gameObject.name == "platform_2(3)")
        {
            hitByOneWaterBallon = false;
            GetComponent<Rigidbody2D>().isKinematic = true;
            hitOnTopPlatform = true;
        }
        else if (col.gameObject.tag == "WaterBallon" && hitOnTopPlatform == true)
        {
            GetComponent<Rigidbody2D>().isKinematic = true;
        }
        else if(col.gameObject.tag == "BalanceNew")
        {
            hitOnTopPlatform = false;
        }
	}

	void turnKinematic(){
		if (this.GetComponent<Rigidbody2D> ().isKinematic == true) {
			this.GetComponent<Rigidbody2D> ().isKinematic = false;
		}
	}
}
