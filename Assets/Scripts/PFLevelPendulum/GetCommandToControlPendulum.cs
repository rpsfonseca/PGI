using UnityEngine;
using System.Collections;

public class GetCommandToControlPendulum : MonoBehaviour {
    public bool weCanControlPendulum = false;
    public GameObject comando;
    public BoxCollider2D comandoBoxColl2D;
    public SpriteRenderer comandoSprite;
    public GameObject pendulum;
    public DistanceJoint2D pendulumController;
    public GameObject magneticMachine;
    private Rigidbody2D pendulumRigidBody2D;
    private float maximumDistanceBetweenPendulumAndMachine;
    private bool pendulumAquired;
    private bool tryingToAquirePendulum;
    // Use this for initialization
    void Start () {
        comandoBoxColl2D = comando.GetComponent<BoxCollider2D>();
        comandoSprite = comando.GetComponent<SpriteRenderer>();
        pendulumController = pendulum.GetComponent<DistanceJoint2D>();
        maximumDistanceBetweenPendulumAndMachine = 6.48f;
        pendulumRigidBody2D = pendulum.GetComponent<Rigidbody2D>();
        pendulumAquired = false;
        tryingToAquirePendulum = false;
    }
	
	// Update is called once per frame
	void Update () {
        if(tryingToAquirePendulum == true &&
            Vector2.Distance(pendulum.transform.position, magneticMachine.transform.position) < maximumDistanceBetweenPendulumAndMachine + 0.1 
            && Vector2.Distance(pendulum.transform.position, magneticMachine.transform.position) > maximumDistanceBetweenPendulumAndMachine - 0.1)
        {
            //get the pendulum with the machine without causing trouble on the rope
            pendulumController.distance = Vector2.Distance(pendulum.transform.position, magneticMachine.transform.position);
            pendulumController.enabled = true;
            tryingToAquirePendulum = false;
        }
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
            tryingToAquirePendulum = true;
        }
    }
}
