using UnityEngine;
using System.Collections;

public class MouseColor : MonoBehaviour 
{
    public bool isQuit = false;

    void OnMouseEnter()
    {
        renderer.material.color = Color.red;
    }

    void OnMouseExit()
    {
        renderer.material.color = Color.white;
    }

    void OnMouseDown()
    {
        if(isQuit)
        {
            Application.Quit();
        }
        else
        {
            Difficulty.stageVariableForHealthModifier = 0;
            Difficulty.stageVariableForHomingEnemyHealth = 0;
            Difficulty.stageVariableForSpeedModifier = 0;
            Difficulty.homingEnemyHealthModifier = 0;
            Difficulty.regularEnemyHealthModifier = 0;
            Difficulty.regularEnemySpeedModifier = 0;
            Difficulty.homingEnemySpeedModifier = 0;
            EnemySpawn.delay = -5f;
            Application.LoadLevel("Stage1");
        }
    }
}
