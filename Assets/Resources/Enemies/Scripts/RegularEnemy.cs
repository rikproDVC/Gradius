﻿using UnityEngine;
using System.Collections;

public class RegularEnemy: MonoBehaviour
{
    //make variables for Gameobjects spawns; cache transform
	private Transform myTransform;
    public GameObject PowerUpFab;
    public GameObject ExplosionFab;

    //make variables for enemy attributes
	private int Health = 2;
    private Vector3 position;
	private float enemySpeed = EnemySpawn.enemySpeed;

    //make a vraible to get the enemy's position
    private Vector3 position;
	
	// Use this for initialization
	void Start()
	{
        //cache transform
		myTransform = transform;
	}
	
	// Update is called once per frame
	void Update()
	{
		myTransform.Translate (Vector3.up * enemySpeed * Time.deltaTime);
        if (myTransform.position.x < General.leftBorder || myTransform.position.x > General.rightBorder)
		{
			Destroy(this.gameObject);
		}

		if (Health <= 0)
		{
			Player.PlayerScore += 100;
            position = new Vector3(myTransform.position.x, myTransform.position.y, myTransform.position.z);   
                                       
			if(Random.Range(1, 5) == 1)
			{
                position = new Vector3(myTransform.position.x, myTransform.position.y, myTransform.position.z);
                Instantiate(PowerUpFab, position, Quaternion.identity);
			}
			Destroy(this.gameObject);
		}
	}

	// Collision detector for Player
	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "Player")
		{
			Player.PlayerScore -= 100;
			Destroy(this.gameObject);
		}
	}

	// Collision ...
	void OnTriggerEnter2D(Collider2D other)
	{
		//... with Bullet
		if(other.transform.tag == "Bullet")
		{
			Health -= Bullet.Damage;
		}

		//... with Rocket
		if(other.transform.tag == "Rocket")
		{
			Health -= Rocket.ImpactDamage;
		}

		//... with Explosion
		if(other.transform.tag == "Explosion")
		{
			Health -= Rocket.AreaDamage;
		}

		//... with Laser
//		if(other.transform.tag == "Laser")
//		{
//			Health -= Laser.Damage;
//		}

        //... with Shield
        if(other.transform.tag == "Shield" && Player.ShieldActive == true)
        {
            Health = 0;
        }

        //... with Player
        if(other.transform.tag == "Player" && Player.ShieldActive == false)
        {
            Player.PlayerLives -= 1;
            Health = 0;
        }
	}
}