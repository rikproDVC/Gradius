using UnityEngine;
using System.Collections;

public class RegularEnemy: MonoBehaviour
{
	private Transform MyTransform;
	public static float enemySpeed = 3;
	public int enemyHealth = 12;
	
	// Use this for initialization
	void Start()
	{
		MyTransform = transform;
	}
	
	// Update is called once per frame
	void Update()
	{
		if (MyTransform.position.x < -20)
		{
			Destroy(this.gameObject);
		}

		if (enemyHealth <= 0)
		{
			DestroyObject (this.gameObject);
		}
	}

	// Collision detector for Weapons
	void  OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Bullet")
		{
			Player.PlayerScore += 100;
			enemyHealth -= 4;
		}

		if (other.tag == "Rocket")
		{
			Player.PlayerScore += 100;
			enemyHealth -= 12;
		}
	}

	// Collision detector for Laser
	void onTriggerStay2D(Collider2D other)
	{
		if (other.tag == "Laser")
		{
			Player.PlayerScore += 100;
			enemyHealth -= 1;
		}
	}

	// Collision detector for Player
	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "Player")
		{
			Player.PlayerScore -= 100;
			Destroy (this.gameObject);
		}
	}
}