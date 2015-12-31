using UnityEngine;
using System.Collections;

public class InvisibleWallToStopBox : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Ballon"),
                                 LayerMask.NameToLayer("WallForBox"),
                                 true
                                );
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
