using UnityEngine;
using System.Collections;

public class TrampolineBehaviour : MonoBehaviour
{
    private Animator anim;
    private float trampolineJumpForce;
    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        trampolineJumpForce = 900;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D col)
    {	

        if (col.gameObject.name == "Character")
        {
			GetComponent<AudioSource> ().time = 0.6f;
			GetComponent<AudioSource> ().Play ();
            anim.SetTrigger("OnTramp");
            anim.SetBool("Ground", false);
            col.rigidbody.AddForce(new Vector2(0, trampolineJumpForce));
        }
    }

}
