using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CharacterMov : MonoBehaviour {

	public float maxSpeed = 10f;
	bool facingRight = true;
	bool bounce;
	bool isLadder = false;

    public BoxCollider2D ladderCollider;
	public bool grounded  = false;
	public Transform groundCheck;
	public float groundRadious = 0.2f;
	public LayerMask whatIsGround;
	public float jumpForce = 0;
	public Camera camera;
    private Rigidbody2D thisRigidBody;
    private bool dead;
    private bool startedAnim;
    private bool deadByFall;


	Vector2 normalGrav;

	Animator anim;
	
	void Start () {
        deadByFall = false;
		Time.timeScale = 1;
		anim = GetComponent<Animator> ();
        thisRigidBody = GetComponent<Rigidbody2D>();
        dead = false;
        startedAnim = false;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if (dead)
        {
            if (!startedAnim)
            {
                startedAnim = true;
                anim.SetBool("Ground", true);
                anim.SetTrigger("Dead");
                //anim.Play("Dead");
                if (deadByFall)
                {
                    StartCoroutine(LoadLevelAfterDeadByFall());
                    return;
                }
                StartCoroutine(LoadLevel());
            }
            return;
        }
        grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadious, whatIsGround);
        anim.SetBool("Ground", grounded);
        anim.SetFloat("vSpeed", thisRigidBody.velocity.y);
        //Debug.Log(thisRigidBody.velocity.y);
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Character"),
                                 LayerMask.NameToLayer("OneWayPlatform"),
                                 !grounded || thisRigidBody.velocity.y > 0 || isLadder
                                );
        if (camera.GetComponent<BaseCamera> ().getMapOn () == false) {
			float move = Input.GetAxis ("Horizontal");
			anim.SetFloat ("Speed", Mathf.Abs (move));
			if(isLadder == true){
				float move2 = Input.GetAxis("Vertical");
                
                GetComponent<Rigidbody2D>().velocity = new Vector2(move * maxSpeed, move2 * maxSpeed / 2); 
                BoxCollider2D tmpBC = GetComponent<BoxCollider2D>();
                float characterBottom = tmpBC.bounds.min.y;
                if(characterBottom >= ladderCollider.bounds.max.y)
                {
                    if (move2 > 0)
                    {
                        GetComponent<Rigidbody2D>().velocity = new Vector2(move * maxSpeed, 0);
                    }
                }
            }
			else{
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (move * maxSpeed, GetComponent<Rigidbody2D> ().velocity.y); 
			}



			if (move > 0 && !facingRight)
				Flip ();
			else if (move < 0 && facingRight)
				Flip ();  


		} else {
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, 0);
			anim.SetFloat ("Speed", Mathf.Abs (0));
		}

		stopPoofGravity ();

	} 

	void Update() {
	
		//verticalDeath ();
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
		if (grounded == true && Input.GetKeyDown (KeyCode.Space)) {
			GetComponent<AudioSource> ().pitch = (Random.Range (0.1f, 1.7f));
			GetComponent<AudioSource> ().Play ();
            anim.SetBool("Ground", false);
			GetComponent<Rigidbody2D> ().AddForce (new Vector2 (0, jumpForce));
		}

	}


	void verticalDeath() {

		if (bounce == false && grounded == true && GetComponent<Rigidbody2D> ().velocity.y < -15) {
			Application.LoadLevel(Application.loadedLevel);
		}

	}

	void OnCollisionEnter2D (Collision2D col){
        if(col.collider.sharedMaterial != null) {
            if (col.collider.sharedMaterial.bounciness > 0)
            {
                bounce = true;
            }
            else
                bounce = false;
            Debug.Log("Bounce?? :: " + bounce);
        }	
	}

	public void setIsLadder(bool value){
		isLadder = value;
	}

	public void stopPoofGravity(){
		float grav = Physics2D.gravity.y;
		if (isLadder == true) {
			GetComponent<Rigidbody2D> ().AddForce(new Vector2(0, -grav));
		}
	}

    private IEnumerator LoadLevel()
    {
        if (facingRight)
        {
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
        yield return new WaitForSeconds(1);
        Application.LoadLevel(Application.loadedLevel);
    }

    private IEnumerator LoadLevelAfterDeadByFall()
    {
        yield return new WaitForSeconds(1);
        Application.LoadLevel(Application.loadedLevel);
    }

    public void setDead()
    {
        dead = true;
    }

    public void setDeadByFall()
    {
        deadByFall = true;
    }

}
