using UnityEngine;
using System.Collections;

public class EggBehavior : MonoBehaviour {

	GameObject character;
	public GameObject leftWall;
	public GameObject rightWall;
	public GameObject balloon;
    private Animator anim;

	
	float randomness;


	// Use this for initialization
	
	void Start () {
        anim = GetComponent<Animator>();
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Egg"),
                                       LayerMask.NameToLayer("GreenPlatform"),
                                       true
                                       );
        character = GameObject.Find ("Character");

		randomness = rightWall.transform.position.x - leftWall.transform.position.x;
		transform.position = new Vector3 (rightWall.transform.position.x - ( randomness * Random.value) , character.transform.position.y + 13, transform.position.z);
		if (transform.position.x <= leftWall.transform.position.x + 2)
			transform.position = new Vector3 (leftWall.transform.position.x + 2f, transform.position.y, transform.position.z);

	}
	
	

	void OnCollisionEnter2D( Collision2D col){
		if (!col.gameObject.name.Equals ("Egg")) {
            anim.SetTrigger("Explode");
            StartCoroutine(DestroyEgg());
		}

		//if (col.gameObject.name.Equals ("Character")) {
		//	script.GetComponent<BalloonBehavior> ().setFlying (false);
		//} else if(!this.name.Equals("Egg")) {
		//	Destroy(this.gameObject);
		//}
	}

    private IEnumerator DestroyEgg()
    {
        yield return new WaitForSeconds(1);
        Destroy(this.gameObject);
    }
}
