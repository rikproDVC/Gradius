using UnityEngine;
using System.Collections;

public class Difficulty : MonoBehaviour {

    public static int regularEnemyHealth;
    public static int homingEnemyHealth;

    public static int regularEnemyHealthModifier;
    public static int homingEnemyHealthModifier;
    public static float regularEnemySpeedModifier;
    public static float homingEnemySpeedModifier;

    public static int stageForHealthModifier;
    public static int stageForHomingEnemyHealth;
    public static int stageForSpeedModifier;

	// Use this for initialization
	void Start () {
        stageForHealthModifier = 0;
        stageForHomingEnemyHealth = 0;
        stageForSpeedModifier = 0;
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
        regularEnemySpeedModifier = stageForHomingEnemyHealth / 20;
        homingEnemySpeedModifier = stageForSpeedModifier / 5;

        if (stageForHealthModifier > 10)
        {
            regularEnemyHealthModifier += 4;
            stageForHealthModifier = 0;
        }
        if (stageForHomingEnemyHealth > 20)
        {
            homingEnemyHealthModifier +=4;
            stageForHomingEnemyHealth = 0;
        }
	}
}
