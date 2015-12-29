using UnityEngine;
using System.Collections;

public class SpeechBallonBehavior : MonoBehaviour {
    public int level;
    public Transform characterTransform;
    public Sprite moveRightSprite;
    public Sprite endLevelSprite;
    public GameObject arrowEnd;
    private bool movedRight;
    private bool movedLeft;
	// Use this for initialization
	void Start () {
        transform.localPosition = characterTransform.localPosition + new Vector3(1.5f,1,0);
        movedLeft = false;
        movedRight = false;
        arrowEnd.SetActive(false);
    }
	
	void Update () {
        transform.localPosition = characterTransform.localPosition + new Vector3(1.5f, 1, 0);
        if (level == 1)
        {
            float move = Input.GetAxis("Horizontal");
            if (move < 0 && movedRight == false)
            {
                movedLeft = true;
                GetComponent<SpriteRenderer>().sprite = moveRightSprite;
            }
            if(move > 0 && movedLeft == true && movedRight == false)
            {
                movedRight = true;
                GetComponent<SpriteRenderer>().sprite = endLevelSprite;
                arrowEnd.SetActive(true);
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                movedRight = true;
                movedLeft = true;
                arrowEnd.SetActive(true);
                Destroy(gameObject);
            }
        }
    }

    public bool getFinished()
    {
        if(movedRight == true && movedLeft == true)
        {
            return true;
        }
        return false;
    }
}
