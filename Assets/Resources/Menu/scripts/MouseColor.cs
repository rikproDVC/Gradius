using UnityEngine;
using System.Collections;

public class MouseColor : MonoBehaviour 
{
    public bool isQuit = false;
    public bool isSound = false;
    public bool isMenu = false;

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
        if (isQuit)
        {
            Application.Quit();
        }
        if (isSound)
        {
            Application.LoadLevel("SoundOptions");
        }
        if (isMenu)
        {
            Application.LoadLevel("Menu");
        }
        else
        {
            Difficulty.stageForRegEnemyHealth = 0;
            Difficulty.stageForHomingEnemyHealth = 0;
            Difficulty.stageForSpeedModifier = 0;
            Difficulty.homingEnemyHealthModifier = 0;
            Difficulty.regularEnemyHealthModifier = 0;
            Difficulty.regularEnemySpeedModifier = 0;
            Difficulty.homingEnemySpeedModifier = 0;
            EnemySpawn.delay = -5f;
            Application.LoadLevel("Stage1");
        }
    }
}
