using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CharacterMov : MonoBehaviour {

	public float maxSpeed = 10f;
	bool facingRight = true;
	bool bounce;



	public bool grounded  = false;
	public Transform groundCheck;
	float groundRadious = 0.2f;
	public LayerMask whatIsGround;
	public float jumpForce = 0;
	public Camera camera;

	Vector2 normalGrav;

	Animator anim;
	
	void Start () {
		Time.timeScale = 1;
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadious, whatIsGround);
		 

		if (camera.GetComponent<BaseCamera> ().getMapOn () == false) {
			float move = Input.GetAxis ("Horizontal");
			anim.SetFloat ("Speed", Mathf.Abs (move));
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (move * maxSpeed, GetComponent<Rigidbody2D> ().velocity.y); 

			if (move > 0 && !facingRight)
				Flip ();
			else if (move < 0 && facingRight)
				Flip ();  


		} else {
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, 0);
			anim.SetFloat ("Speed", Mathf.Abs (0));
		}

	} 

	void Update() {
	
		verticalDeath ();
		Jump ();
		//Debug.Log (" Vertical velocity: " + GetComponent<Rigidbody2D> ().velocity.y);

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

		if (bounce == false && grounded == true && GetComponent<Rigidbody2D> ().velocity.y < -15) {
			Application.LoadLevel(Application.loadedLevel);
		}

	}

	void OnCollisionEnter2D (Collision2D col){
		if (col.collider.sharedMaterial.bounciness > 0) {
			bounce = true;
		} else
			bounce = false;
		Debug.Log ("Bounce?? :: " + bounce);
	}
}
