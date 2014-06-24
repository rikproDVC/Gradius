using UnityEngine;
using System.Collections;

public class RegularEnemy: MonoBehaviour
{
    //make variables for Gameobjects spawns; cache transform
	private Transform myTransform;
    public GameObject PowerUpFab;
    public GameObject ExplosionFab;
<<<<<<< HEAD

    //make variables for enemy attributes
	private float enemySpeed = EnemySpawn.enemySpeed;
    private Vector3 position;
    private int Health = 4;
    private float Timer = 0f;
    private bool ExplosionDamage = false;
=======
    private Vector3 position;

    //make variables for enemy attributes
    private float Speed;
    public int Health;
>>>>>>> bd59aab94a264260632a0274692efdfda085f4a4

	// Use this for initialization
	void Start()
    {
        //cache transform
        myTransform = transform;

        Speed = 8 + Difficulty.regularEnemySpeedModifier;
        Health = Difficulty.regularEnemyHealth;
	}
	
	// Update is called once per frame
	void Update()
	{
		myTransform.Translate (Vector3.up * Speed * Time.deltaTime);


        if (myTransform.position.x < -20)
        {
            Destroy(this.gameObject);
        }


        if (myTransform.position.x < General.leftBorder || myTransform.position.x > General.rightBorder)
		{
			Destroy(this.gameObject);
		}


		if (Health <= 0)
		{
			Player.PlayerScore += 100;
                                       
			if(Random.Range(1, 15) == 1)
			{


                position = new Vector3(myTransform.position.x, myTransform.position.y, myTransform.position.z);
              

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
            Health = 0;
        }

        //... with Player
        if(other.transform.tag == "Player" && Player.ShieldActive == false)
        {
            Player.PlayerLives -= 1;
            Health = 0;
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