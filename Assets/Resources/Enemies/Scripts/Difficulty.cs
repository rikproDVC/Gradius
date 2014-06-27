using UnityEngine;
using System.Collections;

public class Difficulty : MonoBehaviour {
    //Get the wave number to get the difficulty level
    public static int stageForRegEnemyHealth = EnemySpawn.wave;
    public static int stageForHomingEnemyHealth = EnemySpawn.wave;
    public static int stageForSpeedModifier = EnemySpawn.wave;

    // make variables for setting health and speed variables in enemies
    public static int regularEnemyHealthModifier;
    public static int homingEnemyHealthModifier;
    public static float regularEnemySpeedModifier;
    public static float homingEnemySpeedModifier;

	// Use this for initialization
	void Start()
    {
        if (stageForRegEnemyHealth > 50)
        {
            regularEnemyHealthModifier += 4;
            stageForRegEnemyHealth -= 10;
        }
        if (stageForRegEnemyHealth > 40)
        {
            regularEnemyHealthModifier += 4;
            stageForRegEnemyHealth -= 10;
        }
        if (stageForRegEnemyHealth > 30)
        {
            regularEnemyHealthModifier += 4;
            stageForRegEnemyHealth -= 10;
        }
        if (stageForRegEnemyHealth > 20)
        {
            regularEnemyHealthModifier += 4;
            stageForRegEnemyHealth -= 10;
        }
        if (stageForRegEnemyHealth > 10)
        {
            regularEnemyHealthModifier += 4;
            stageForRegEnemyHealth -= 10;
        }

        if (stageForHomingEnemyHealth > 100)
        {
            homingEnemyHealthModifier += 4;
            stageForHomingEnemyHealth -= 10;
        }
        if (stageForHomingEnemyHealth > 80)
        {
            homingEnemyHealthModifier += 4;
            stageForHomingEnemyHealth -= 10;
        }
        if (stageForHomingEnemyHealth > 60)
        {
            homingEnemyHealthModifier += 4;
            stageForHomingEnemyHealth -= 10;
        }
        if (stageForHomingEnemyHealth > 40)
        {
            homingEnemyHealthModifier += 4;
            stageForHomingEnemyHealth -= 10;
        }
        if (stageForHomingEnemyHealth > 20)
        {
            homingEnemyHealthModifier += 4;
            stageForHomingEnemyHealth -= 10;
        }
        
        regularEnemySpeedModifier = stageForSpeedModifier / 10;
        homingEnemySpeedModifier = stageForSpeedModifier / 20;
	}
	
	// Update is called once per frame
	void Update()
    {

	}
}
