using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CharacterMov : MonoBehaviour {

	public float maxSpeed = 10f;
	bool facingRight = true;



	public bool grounded  = false;
	public Transform groundCheck;
	float groundRadious = 0.2f;
	public LayerMask whatIsGround;
	public float jumpForce = 0;

	Animator anim;
	
	void Start () {
		Time.timeScale = 1;
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadious, whatIsGround);
		 
		float move = Input.GetAxis ("Horizontal");
		anim.SetFloat("Speed", Mathf.Abs (move));
		GetComponent<Rigidbody2D> ().velocity = new Vector2 (move * maxSpeed, GetComponent<Rigidbody2D> ().velocity.y);




		 
		if (move > 0 && !facingRight)
			Flip ();
		else if (move < 0 && facingRight)
			Flip ();  
	} 

	void Update() {
	
		verticalDeath ();
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


	void verticalDeath() {
		if (grounded == true && GetComponent<Rigidbody2D> ().velocity.y < -7.5) {
			Application.LoadLevel(Application.loadedLevel);
		}
	}


}
