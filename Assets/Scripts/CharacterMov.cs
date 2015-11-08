using UnityEngine;
using System.Collections;

public class CharacterMov : MonoBehaviour {

	public float maxSpeed = 10f;
	bool facingRight = true;


	bool grounded  = false;
	public Transform groundCheck;
	float groundRadious = 0.2f;
	public LayerMask whatIsGround;
	public float jumpForce = 0;
	 

	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadious, whatIsGround);
		 

		float move = Input.GetAxis ("Horizontal");
		GetComponent<Rigidbody2D>().velocity = new Vector2 (move * maxSpeed, GetComponent<Rigidbody2D>().velocity.y);



		 
		/*if (move > 0 && !facingRight)
			Flip ();
		else if (move < 0 && facingRight)
			Flip ();  */
	}

	void Update() {
		Jump ();
	}

	void Flip(){
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	void Jump(){
		if (grounded == true && Input.GetKeyDown(KeyCode.Space))
			GetComponent<Rigidbody2D>().AddForce (new Vector2 (0, jumpForce));

	}


}
