using UnityEngine;
using System.Collections;

public class RegularEnemy: MonoBehaviour
{
    public GameObject PowerUpFab;
    public GameObject ExplosionFab;
    private int Health;
    private float Speed;

	private Transform myTransform;
    private Vector3 position;
    private float Timer = 0f;
    private bool ExplosionDamage = false;

    //Get the wave number to get the difficulty level
    private int stageForRegEnemyHealth = EnemySpawn.wave;
    private int stageForSpeedModifier = EnemySpawn.wave;
    
    // make variables for setting health and speed variables in enemies
    private int regularEnemyHealthModifier;
    private float regularEnemySpeedModifier;

	// Use this for initialization
	void Start()
    {
        //cache transform
        myTransform = transform;

        if (stageForRegEnemyHealth > 50)
        {
            regularEnemyHealthModifier += 4;
            stageForRegEnemyHealth -= 10;
        }
        if (stageForRegEnemyHealth > 40)
        {
            regularEnemyHealthModifier += 4;
            stageForRegEnemyHealth -= 10;
        }
        if (stageForRegEnemyHealth > 30)
        {
            regularEnemyHealthModifier += 4;
            stageForRegEnemyHealth -= 10;
        }
        if (stageForRegEnemyHealth > 20)
        {
            regularEnemyHealthModifier += 4;
            stageForRegEnemyHealth -= 10;
        }
        if (stageForRegEnemyHealth > 10)
        {
            regularEnemyHealthModifier += 4;
            stageForRegEnemyHealth -= 10;
        }

        regularEnemySpeedModifier = stageForSpeedModifier / 10;

        Speed = 8 + regularEnemySpeedModifier;
        Health = 4 + regularEnemyHealthModifier;
	}
	
	// Update is called once per frame
	void Update()
	{
        //make enemy move forward
		myTransform.Translate (Vector3.up * Speed * Time.deltaTime);

        //destroy the enemy if out of screen
        if (myTransform.position.x < General.leftBorder || myTransform.position.x > General.rightBorder)
		{
			Destroy(this.gameObject);
		}
        //destroy the enemy at 0hp with chance of dropping a powerup
		if (Health <= 0)
		{
			Player.PlayerScore += 100;
                                       
			if(Random.Range(1, 15) == 1)
            {
                position = new Vector3(myTransform.position.x, myTransform.position.y, myTransform.position.z);
                Instantiate(PowerUpFab, position, Quaternion.identity);
			}
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
            Destroy(other.gameObject);
		}

		//... with Rocket
		if(other.transform.tag == "Rocket")
		{
			Health -= Rocket.ImpactDamage;
		}

        //... with Shield
        if(other.transform.tag == "Shield" && Player.ShieldActive == true)
        {
            Destroy(this.gameObject);
        }

        //... with Player
        if(other.transform.tag == "Player" && Player.ShieldActive == false)
        {
            Player.PlayerLives -= 1;
            Destroy(this.gameObject);
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        //...with Laser
        if(other.transform.tag == "Laser")
        {
            if(Time.time - Timer > Laser.ROF)
            {
                Health -= Laser.Damage;
                Timer = Time.time;
            }
        }

        //... with Explosion
        if(other.transform.tag == "Explosion")
        {
            if(ExplosionDamage == false)
            {
                Health -= Rocket.AreaDamage;
                ExplosionDamage = true;
            }
        }
    }
}