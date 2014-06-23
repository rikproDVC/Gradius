using UnityEngine;
using System.Collections;

public class Difficulty : MonoBehaviour {

    public static int regularEnemyHealth;
    public static int homingEnemyHealth;

    public static int regularEnemyHealthModifier;
    public static int homingEnemyHealthModifier;
    public static float regularEnemySpeedModifier;
    public static float homingEnemySpeedModifier;

    public static int stageVariableForHealthModifier;
    public static int stageVariableForHomingEnemyHealth;
    public static int stageVariableForSpeedModifier;

	// Use this for initialization
	void Start () {
        stageVariableForHealthModifier = 0;
        stageVariableForHomingEnemyHealth = 0;
        stageVariableForSpeedModifier = 0;
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
        regularEnemySpeedModifier = stageVariableForHomingEnemyHealth / 20;
        homingEnemySpeedModifier = stageVariableForSpeedModifier / 5;

        if (stageVariableForHealthModifier > 10)
        {
            regularEnemyHealthModifier += 4;
            stageVariableForHealthModifier = 0;
        }
        if (stageVariableForHomingEnemyHealth > 20)
        {
            homingEnemyHealthModifier +=4;
            stageVariableForHomingEnemyHealth = 0;
        }
	}
}
