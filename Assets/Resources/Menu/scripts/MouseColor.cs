using UnityEngine;
using System.Collections;

public class MouseColor : MonoBehaviour 
{
    public bool isQuit = false;
    public bool isSound = false;
    public bool isMenu = false;
    public GameObject sounds;

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
            pause.paused=false;
            pause.over=false;
            Application.LoadLevel("Menu");
        }
        else
        {
            pause.paused=false;
            pause.over=false;
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
