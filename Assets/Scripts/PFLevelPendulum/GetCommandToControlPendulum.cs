using UnityEngine;
using System.Collections;

public class GetCommandToControlPendulum : MonoBehaviour {
    public bool weCanControlPendulum = false;
    public GameObject comando;
    public BoxCollider2D comandoBoxColl2D;
    public SpriteRenderer comandoSprite;
    public GameObject pendulum;
    public DistanceJoint2D pendulumController;
    private float maximumDistanceBetweenPendulumAndMachine;
    // Use this for initialization
    void Start () {
        comandoBoxColl2D = comando.GetComponent<BoxCollider2D>();
        comandoSprite = comando.GetComponent<SpriteRenderer>();
        pendulumController = pendulum.GetComponent<DistanceJoint2D>();
        maximumDistanceBetweenPendulumAndMachine = 2.94f;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D objectThatWeCollide)
    {
        if (objectThatWeCollide.gameObject == comando)
        {
            //Now we can get control of pendulum
            weCanControlPendulum = true;
            comandoBoxColl2D.enabled = false;
            comandoSprite.enabled = false;
            //when we get the "comando" we enable the distance joint between the machine and the pendulum
            //We just can control the distance when character is in contact with pendulum
            pendulumController.distance = maximumDistanceBetweenPendulumAndMachine;
            pendulumController.enabled = true;
        }
    }
}
