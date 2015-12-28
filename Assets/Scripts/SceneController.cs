using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SceneController : MonoBehaviour {
    int levelToLoad;
    public Text infoText;
    RectTransform text;

    // Use this for initialization
    void Start () {
        levelToLoad = PlayerPrefs.GetInt("lastlevel");
        ChangeInfo(levelToLoad);

    }
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ButtonDoAction(){
		if (levelToLoad == 7)
			Application.LoadLevel (0);
		Application.LoadLevel (levelToLoad + 1);
	}

    public void ChangeInfo(int lvl) {

        /*if (lvl == 1) {
            infoText.text = "Use A to move to the left and D \nto move to the right!";
        }
        else if (lvl == 2) {
            infoText.text = "Great! Now go to the right by pressing D!";
        }
        else if (lvl == 3) {
            infoText.text = "Great! Now go to the left by pressing A!";
        }
        else if (lvl == 4) {
            infoText.text = "Good! Now you got it! Pass the sign with the \narrow  to go to the next level!";
        }*/
        if (lvl == 5) {
            GetComponentInChildren<Text>().text = "A pendulum is a system comprising a mass coupled to a pivot that allows its movement freely. The mass is subject to the restoring force caused by gravity. The simplest model , and it has increased use is the Simple Pendulum . This pendulum consists of a mass attached to a flexible wire and inextensible by one end and free for other, represented as follows: pêndulo When we turn the mass of the rest position and let go, the pendulum performs oscillations.To disregard air resistance, the only forces acting on the pendulum are tensions with the cord and the weight of mass m.This way: pêndulo1 The weight force component that is given by P.cosθ be canceled with the thread tension force, therefore, the only cause of oscillatory motion is P.senθ.So:pêndulo2 Nonetheless, the angle θ expressed in radians which by definition is given by the quotient of the arc described by the angle which the oscillating motion of a pendulum is x - ray application even in the case, given by ℓ, as follows:pêndulo Where to replace: pêndulo4 Thus it concludes that the motion of a simple pendulum does not describe a MHS, as the force is not proportional to the elongation but to her sine.However, for small angles, pêndulo5, the value of the sine of the angle is approximately equal to this angle. So when we consider the case of small oscillation angle : pêndulo6 As P = mg in g and ℓ are constant in this system, we can consider that : pêndulo7 Then we rewrite the restoring force of the system as pêndulo8 Thus, the analysis of a simple pendulum shows us that for small oscillations, a simple pendulum describes a MHS. As for any MHS, the period is given by: pêndulo9 It is like pêndulo10 Then the period of a simple pendulum can be expressed by: pêndulo11";
        }
        else if (lvl == 6) {
            GetComponentInChildren<Text>().text = "Gravity is the attractive pull between two objects that have mass. The strength of gravity is directly proportional to the amount of mass of each object. In other words, the larger the objects, the greater the gravitational attraction between them. For example, the gravitational pull you experience on Earth is much greater than it would be on the moon because the Earth's mass is greater. An object with twice as much mass will exert twice as much gravitational pull on other objects. The gravitational force increases as the size of an object increases. On the other hand, the strength of gravity is inversely related to the square of the distance between two objects. For example, if the distance between two objects doubles, meaning they're twice as far apart, the gravitational pull decreases by a factor of 4. This is because 2 squared is equal to 4. This means the effect of distance on gravitational attraction is greater than the effect of the masses of the objects. Gravity is most accurately described by the general theory of relativity proposed by Albert Einstein in 1915 which describes gravity, not as a force, but as a consequence of the curvature of spacetime caused by the uneven distribution of mass / energy; and resulting in time dilation, where time lapses more slowly in strong gravitation. However, for most applications, gravity is well approximated by Newton's law of universal gravitation, which postulates that gravity is a force where two bodies of mass are directly drawn (or 'attracted') to each other according to a mathematical relationship, where the attractive force is proportional to the product of their masses and inversely proportional to the square of the distance between them. This is considered to occur over an infinite range, such that all bodies (with mass) in the universe are drawn to each other no matter how far they are apart.";
        } else {
            //infoText.text = "*PLACEHOLDER, WAITING FOR TEXTS WHATEVER*";
            ButtonDoAction();
        }
    }
}
