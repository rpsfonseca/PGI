using UnityEngine;
using System.Collections;

public class AttachCharacterToPendulum : MonoBehaviour {
    private Rigidbody2D pendulumRigidBody2D;
    private DistanceJoint2D pendulumDistanceJoint2D;
    private CircleCollider2D pendulumCircleColl2D;
    private Rigidbody2D characterRigidBody2D;
    private bool characterIsAttachedToPendulum;
    private DistanceJoint2D characterDistanceJoint2D;
    private BoxCollider2D characterBoxCollider2D;
    private Animator characterAnimator;
    private CharacterMov characterMovScript;
    private float maximumPendulumMovement;
    private float distanceBetweenPendulumAndMachine;
    private bool firstTap;
    private float maximumDistanceBetweenPendulumAndMachine;
    private float minimumDistanceBetweenPendulumAndMachine;
    private float trackingTimeSinceLastCollisionWithPendulum;
    private bool characterJumpedFromPendulum;
    private GetCommandToControlPendulum controllerOfPendulum;

    // Use this for initialization
    void Start () {
        pendulumRigidBody2D = GetComponent<Rigidbody2D>();
        pendulumDistanceJoint2D = GetComponent<DistanceJoint2D>();
        pendulumCircleColl2D = GetComponent<CircleCollider2D>();
        characterIsAttachedToPendulum = false;
        maximumPendulumMovement = 0.01f;
        firstTap = false;
        maximumDistanceBetweenPendulumAndMachine = 6.48f;
        minimumDistanceBetweenPendulumAndMachine = 0.9f;
        trackingTimeSinceLastCollisionWithPendulum = 0;
        characterJumpedFromPendulum = false;
    }
	
	void FixedUpdate () {

        if(characterRigidBody2D != null && characterIsAttachedToPendulum == true)
        {
            if(controllerOfPendulum.weCanControlPendulum == true)
            {
                float move = Input.GetAxis("Horizontal");

                if (pendulumDistanceJoint2D.distance > minimumDistanceBetweenPendulumAndMachine)
                {
                    if (move < 0)
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
                    
                    if (firstTap == true)
                    {
                        //detach character from pendulum
                        characterJumpedFromPendulum = true;
                        trackingTimeSinceLastCollisionWithPendulum = Time.realtimeSinceStartup;
                        characterDistanceJoint2D.enabled = false;
                        characterIsAttachedToPendulum = false;
                        pendulumCircleColl2D.enabled = false;
                        characterBoxCollider2D.enabled = true;
                        characterAnimator.SetBool("HoldOn", false);
                        characterAnimator.SetBool("Ground", false);
                        characterRigidBody2D.mass = 1;
                        characterRigidBody2D.gravityScale = 1;
                    }
                    else
                    {
                        //detach pendulum from machine
                        pendulumDistanceJoint2D.enabled = false;
                        firstTap = true;
                    }
                    
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    //detach character from pendulum
                    characterJumpedFromPendulum = true;
                    trackingTimeSinceLastCollisionWithPendulum = Time.realtimeSinceStartup;
                    characterDistanceJoint2D.enabled = false;
                    characterIsAttachedToPendulum = false;
                    pendulumCircleColl2D.enabled = false;
                    characterBoxCollider2D.enabled = true;
                    characterAnimator.SetBool("HoldOn", false);
                    characterAnimator.SetBool("Ground", false);
                    characterRigidBody2D.mass = 1;
                    characterRigidBody2D.gravityScale = 1;
                }
            }
            
        }
        else if(characterJumpedFromPendulum == true)
        {
            bool CharacterGrounded = Physics2D.OverlapCircle(characterMovScript.groundCheck.position, characterMovScript.groundRadious, characterMovScript.whatIsGround);
            if (CharacterGrounded == true)
            {
                //character has grounded so we want to give him control
                characterJumpedFromPendulum = false;
                characterMovScript.enabled = true;
                characterAnimator.enabled = true;
                pendulumCircleColl2D.enabled = true;
                //show "comando" in the same place it was grabbed so we can pick it again and control the pendulo with machine.
                controllerOfPendulum.weCanControlPendulum = false;
                controllerOfPendulum.comandoBoxColl2D.enabled = true;
                controllerOfPendulum.comandoSprite.enabled = true;
            }
            characterAnimator.SetFloat("vSpeed", characterRigidBody2D.velocity.y);
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
                if(characterRigidBody2D == null)
                {
                    characterRigidBody2D = objectThatWeCollide.rigidbody;
                    characterDistanceJoint2D = objectThatWeCollide.gameObject.GetComponent<DistanceJoint2D>();
                    characterDistanceJoint2D.connectedBody = pendulumRigidBody2D;
                    characterDistanceJoint2D.distance = 0;
                    characterBoxCollider2D = objectThatWeCollide.gameObject.GetComponent<BoxCollider2D>();
                    characterMovScript = objectThatWeCollide.gameObject.GetComponent<CharacterMov>();
                    characterAnimator = objectThatWeCollide.gameObject.GetComponent<Animator>();
                    controllerOfPendulum = objectThatWeCollide.gameObject.GetComponent<GetCommandToControlPendulum>();
                }
                characterBoxCollider2D.enabled = false;
                characterRigidBody2D.mass = 0;
                characterRigidBody2D.gravityScale = 0;
                characterDistanceJoint2D.enabled = true;
                characterIsAttachedToPendulum = true;
                characterMovScript.enabled = false;
                characterAnimator.SetBool("HoldOn", true);
                characterAnimator.SetBool("Ground", true);
                firstTap = false;
                characterJumpedFromPendulum = false;
            }
        }
    }
}
