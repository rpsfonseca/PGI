using UnityEngine;
using System.Collections;

public class AttachCharacterToPendulum : MonoBehaviour {
    private Rigidbody2D pendulumRigidBody2D;
    private DistanceJoint2D pendulumDistanceJoint2D;
    private Rigidbody2D characterRigidBody2D;
    private bool characterIsAttachedToPendulum;
    private DistanceJoint2D characterDistanceJoint2D;
    private float maximumPendulumMovement;
    private float distanceBetweenPendulumAndMachine;
    private bool firstTap;
    private float maximumDistanceBetweenPendulumAndMachine;
    private float minimumDistanceBetweenPendulumAndMachine;
    private float trackingTimeSinceLastCollisionWithPendulum;

    // Use this for initialization
    void Start () {
        pendulumRigidBody2D = GetComponent<Rigidbody2D>();
        pendulumDistanceJoint2D = GetComponent<DistanceJoint2D>();
        characterIsAttachedToPendulum = false;
        maximumPendulumMovement = 0.01f;
        distanceBetweenPendulumAndMachine = 0;
        firstTap = false;
        maximumDistanceBetweenPendulumAndMachine = 2.94f;
        minimumDistanceBetweenPendulumAndMachine = 0.29f;
        trackingTimeSinceLastCollisionWithPendulum = 0;
    }
	
	// Update is called once per frame
	void Update () {
        float move = Input.GetAxis("Horizontal");

        if (pendulumDistanceJoint2D.distance > minimumDistanceBetweenPendulumAndMachine)
        {
            if(move < 0)
            {
                distanceBetweenPendulumAndMachine = pendulumDistanceJoint2D.distance + move * maximumPendulumMovement;
                if (distanceBetweenPendulumAndMachine > minimumDistanceBetweenPendulumAndMachine)
                {
                    pendulumDistanceJoint2D.distance += move * maximumPendulumMovement;
                }
            }
        }

        if (pendulumDistanceJoint2D.distance < maximumDistanceBetweenPendulumAndMachine)
        {
            if (move > 0)
            {
                distanceBetweenPendulumAndMachine = pendulumDistanceJoint2D.distance + move * maximumPendulumMovement;
                if (distanceBetweenPendulumAndMachine < maximumDistanceBetweenPendulumAndMachine)
                {
                    pendulumDistanceJoint2D.distance += move * maximumPendulumMovement;
                }
            }
        }


        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(characterIsAttachedToPendulum == true)
            {
                if (firstTap == true)
                {
                    //detach character from pendulum
                    trackingTimeSinceLastCollisionWithPendulum = Time.realtimeSinceStartup;
                    characterDistanceJoint2D.enabled = false;
                    characterIsAttachedToPendulum = false;
                    characterRigidBody2D.mass = 1;
                    characterRigidBody2D.gravityScale = 1;
                    CircleCollider2D pendulumCircleColl2D = GetComponent<CircleCollider2D>();
                    pendulumCircleColl2D.enabled = false;
                }
                else
                {
                    //detach pendulum from machine
                    pendulumDistanceJoint2D.enabled = false;
                    firstTap = true;
                }
            }
        }
    }

    void OnCollisionEnter2D(Collision2D objectThatWeCollide)
    {
        if (objectThatWeCollide.gameObject.tag == "Player")
        {
            if (characterIsAttachedToPendulum == false && 
                (trackingTimeSinceLastCollisionWithPendulum == 0 || Time.realtimeSinceStartup - trackingTimeSinceLastCollisionWithPendulum > 1))
            {
                trackingTimeSinceLastCollisionWithPendulum = 0;
                characterRigidBody2D = objectThatWeCollide.rigidbody;
                characterDistanceJoint2D = objectThatWeCollide.gameObject.GetComponent<DistanceJoint2D>();
                characterDistanceJoint2D.connectedBody = pendulumRigidBody2D;
                characterDistanceJoint2D.distance = 0;
                characterDistanceJoint2D.enabled = true;
                characterIsAttachedToPendulum = true;
                objectThatWeCollide.gameObject.GetComponent<BoxCollider2D>().enabled = false;
                objectThatWeCollide.gameObject.GetComponent<CharacterMov>().enabled = false;
                objectThatWeCollide.gameObject.GetComponent<Animator>().enabled = false;
                //characterRigidBody2D.mass = 0;
                //characterRigidBody2D.gravityScale = 0;
                firstTap = false;
            }
        }
    }
}
