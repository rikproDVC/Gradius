using UnityEngine;
using System.Collections;

public class myGUI : MonoBehaviour {

    private float screenWidth;
    private float screenHeight;

    void Start()
    {
        screenWidth = Camera.main.pixelWidth;
        screenHeight = Camera.main.pixelHeight;
    }

	void OnGUI()
	{
		GUI.backgroundColor = Color.red;
        GUI.Box (new Rect(screenWidth / 2, 1, 80, 25), "Score: " + Player.PlayerScore);
        GUI.Box (new Rect(screenWidth / 2, 25, 80, 25), "Stage: " + EnemySpawn.wave);
        GUI.Box (new Rect(screenWidth - 275, screenHeight - 25, 275, 25),  "Battery: " + LaserPU.LaserCharge + "  Rocket Ammo: " + RocketPU.RocketAmmo + "  Shield: " + Player.Shield);
        GUI.Box (new Rect(1, screenHeight - 25, 80, 25), "Lives: " + Player.PlayerLives);
	}
}

