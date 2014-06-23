using UnityEngine;
using System.Collections;

public class Difficulty : MonoBehaviour {

    public static int regularEnemyHealth;
    public static int homingEnemyHealth;

    public static int regularEnemyHealthModifier;
    public static int homingEnemyHealthModifier;
    public static float regularEnemySpeedModifier;
    public static float homingEnemySpeedModifier;

    public static int stage;
    public static int theSecondStageVariable;
    public static int thatOtherStageVariable;

	// Use this for initialization
	void Start () {
        stage = 0;
        theSecondStageVariable = 0;
        thatOtherStageVariable = 0;
        homingEnemyHealthModifier = 0;
        regularEnemyHealthModifier = 0;
        regularEnemySpeedModifier = 0;
        homingEnemySpeedModifier = 0;
	}
	
	// Update is called once per frame
	void Update()
    {
        regularEnemyHealth = 3 + regularEnemyHealthModifier;
        homingEnemyHealth = 7 + homingEnemyHealthModifier;
        regularEnemySpeedModifier = theSecondStageVariable / 20;
        homingEnemySpeedModifier = thatOtherStageVariable / 5;

        if (stage > 10)
        {
            regularEnemyHealthModifier += 4;
            stage = 0;
        }
        if (theSecondStageVariable > 20)
        {
            homingEnemyHealthModifier +=4;
        }
	}
}
