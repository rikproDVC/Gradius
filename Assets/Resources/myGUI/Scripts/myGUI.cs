﻿using UnityEngine;
using System.Collections;

public class myGUI : MonoBehaviour {
		
		void OnGUI()
		{
			GUI.backgroundColor = Color.red;
			GUI.Box (new Rect(1, 1, 410, 40), "Lives: " + Player.PlayerLives + "  Score: " + Player.PlayerScore + "  Battery: " + LaserPU.LaserCharge + "  Rocket Ammo: " + RocketPU.RocketAmmo + "  Shield: " + Player.Shield);
			GUI.Box (new Rect(1, 40, 400, 40), "BulletLevel: " + BulletPU.PowerLevel + "  RocketLevel: " + RocketPU.PowerLevel + "  LaserLevel: " + LaserPU.PowerLevel + "  SpeedLevel: " + Player.PowerLevel);
		}
	}

