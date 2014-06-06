using UnityEngine;
using System.Collections;

public class PowerUp : MonoBehaviour {

	private string[] TypeArray = new string[4] {"Bullet", "Rocket", "Laser", "Player"};
	private int TypeNum;
	private string Type;

	// Use this for initialization
	void Start ()
	{
		TypeNum = Random.Range(0, 4);
		Type = TypeArray[TypeNum];
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	// Collision Detector
	void  OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player")
		{
			if (Type == "Bullet" && BulletPU.PowerLevel < 4)
			{
				BulletPU.PowerLevel += 1;
			}
			if (Type == "Rocket" && RocketPU.PowerLevel < 4)
			{
				RocketPU.PowerLevel += 1;
			}
			if (Type == "Laser" && LaserPU.PowerLevel < 4)
			{
				LaserPU.PowerLevel += 1;
			}
			if (Type == "Player" && Player.PowerLevel < 4)
			{
				Player.PowerLevel += 1;
			}

			Player.PlayerScore += 50;
			Destroy (this.gameObject);
		}
	}
}
