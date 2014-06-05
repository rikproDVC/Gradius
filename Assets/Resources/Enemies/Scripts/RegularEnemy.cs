using UnityEngine;
using System.Collections;

public class RegularEnemy: MonoBehaviour
{
	private Transform MyTransform;
	public static float enemySpeed = 3;
	
	// Use this for initialization
	void Start()
	{
		MyTransform = transform;
	}
	
	// Update is called once per frame
	void Update()
	{
		if (MyTransform.position.x < -30)
		{
			DestroyObject (this.gameObject);
		}
	}
	
	// Collision detector for Player
	void  OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player")
		{
			Player.PlayerScore -= 100;
			Destroy (this.gameObject);
		}

		if (other.gameObject.tag == "Bullet")
		{
			Player.PlayerScore += 100;
			Destroy (this.gameObject);
		}

		if (other.gameObject.tag == "Laser")
		{
			Player.PlayerScore += 100;
			Destroy (this.gameObject);
		}

		if (other.gameObject.tag == "Rocket")
		{
			Player.PlayerScore += 100;
			Destroy (this.gameObject);
		}
	}
}