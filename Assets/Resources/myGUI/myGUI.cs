using UnityEngine;
using System.Collections;

public class myGUI : MonoBehaviour {
		
		void OnGUI()
		{
			GUI.backgroundColor = Color.red;
			GUI.Box (new Rect(1, 1, 150, 40), "Score: " + Player.PlayerScore + "  Laser: " + Player.LaserCharge);
		}
	}

