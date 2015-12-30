using UnityEngine;
using System.Collections;

public class WaterBalloonBehaviour : MonoBehaviour {

	public GameObject launcher;
    private Animator anim;
    private bool exploded;
    private Rigidbody2D ballonRB2D;
    private static int poofHitted = 0;
	// Use this for initialization
	void Start () {
		transform.position = launcher.transform.position;
        anim = GetComponent<Animator>();
        exploded = false;
        ballonRB2D = GetComponent<Rigidbody2D>();
    }



	// Update is called once per frame
	void Update () {
        if (exploded)
        {
            //give gravity to the ballon to move water animation to the soil
            ballonRB2D.mass = 1;
            ballonRB2D.gravityScale = 1;
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(10, 0);
        }
	}

    void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.name.Equals("Character")) {
            launcher.GetComponent<GenerateBalloons>().setWorking(false);
            anim.Play("WaterBallonSplash");
            col.gameObject.GetComponent<CharacterMov>().setDead();
            exploded = true;
            StartCoroutine(DestroyTimer());
        }
        else if (col.gameObject.name.Equals("Box"))
        {
            anim.Play("WaterBallonSplash");
            exploded = true;
            StartCoroutine(DestroyTimer());
        }
        else
        {
            Destroy(this.gameObject);
        }
    }


    private IEnumerator DestroyTimer()
    {
        yield return new WaitForSeconds(2);
        Destroy(this.gameObject);

    }

    

}


