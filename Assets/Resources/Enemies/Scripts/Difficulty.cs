using UnityEngine;
using System.Collections;

public class Difficulty : MonoBehaviour {

    public static int regularEnemyHealth;
    public static int homingEnemyHealth;

    public static int regularEnemyHealthModifier;
    public static int homingEnemyHealthModifier;
    public static float regularEnemySpeedModifier;
    public static float homingEnemySpeedModifier;

    public static int stageForRegEnemyHealth = EnemySpawn.wave;
    public static int stageForHomingEnemyHealth = EnemySpawn.wave;
    public static int stageForSpeedModifier = EnemySpawn.wave;

	// Use this for initialization
	void Start()
    {
        while (stageForRegEnemyHealth > 10)
        {
            regularEnemyHealthModifier =+ 4;
            stageForRegEnemyHealth -= 10;
        }
        while (stageForHomingEnemyHealth > 20)
        {
            homingEnemyHealthModifier =+ 4;
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
