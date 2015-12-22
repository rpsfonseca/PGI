using UnityEngine;
using System.Collections;

public class GetCommandToControlPendulum : MonoBehaviour {
    private bool weCanControlPendulum = false;
	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D objectThatWeCollide)
    {
        if (objectThatWeCollide.gameObject.tag == "Comando")
        {
            //Now we can get control of pendulum
            weCanControlPendulum = true;
            Destroy(objectThatWeCollide.gameObject);
        }
    }
}
