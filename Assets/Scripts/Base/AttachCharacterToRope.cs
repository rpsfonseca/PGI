using UnityEngine;
using System.Collections;

public class AttachCharacterToRope : MonoBehaviour {
    private Rigidbody2D characterRigidBody2D;
    private DistanceJoint2D characterDistanceJoint2D;
    private bool characterIsAttachedToRope;
    private BoxCollider2D characterBoxCollider2D;
    private float trackingTimeSinceLastCollisionWithRope;

    void Awake()
    {
        characterRigidBody2D = GetComponent<Rigidbody2D>();
        characterDistanceJoint2D = GetComponent<DistanceJoint2D>(); 
        characterBoxCollider2D = GetComponent<BoxCollider2D>();
    }

    // Use this for initialization
    void Start () {
        characterDistanceJoint2D.enabled = false;
        characterDistanceJoint2D.distance = 0;
        characterIsAttachedToRope = false;
        trackingTimeSinceLastCollisionWithRope = 0;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void FixedUpdate()
    {
        if (characterIsAttachedToRope == true)
        {
            //The character can left the rope if the player tap to JUMP
            if (Input.GetKeyDown(KeyCode.Space))
            {
                trackingTimeSinceLastCollisionWithRope = Time.realtimeSinceStartup;
                characterDistanceJoint2D.connectedBody = null;
                characterDistanceJoint2D.enabled = false;
                characterIsAttachedToRope = false;
                characterBoxCollider2D.enabled = true;
                
            }
        }
    }

    void OnCollisionEnter2D(Collision2D objectThatWeCollide)
    {
        if (objectThatWeCollide.gameObject.tag == "Rope")
        {
            if(characterIsAttachedToRope == false) {
                Debug.Log("xxx");
                if (trackingTimeSinceLastCollisionWithRope == 0)
                {
                    characterDistanceJoint2D.connectedBody = objectThatWeCollide.rigidbody;
                    characterDistanceJoint2D.enabled = true;
                    characterIsAttachedToRope = true;
                    characterBoxCollider2D.enabled = false;
                    
                }
                else if (Time.realtimeSinceStartup - trackingTimeSinceLastCollisionWithRope > 1){
                    trackingTimeSinceLastCollisionWithRope = 0;
                    characterDistanceJoint2D.connectedBody = objectThatWeCollide.rigidbody;
                    characterDistanceJoint2D.enabled = true;
                    characterIsAttachedToRope = true;
                    characterBoxCollider2D.enabled = false;
                    
                }
            }
        }
    }
}
