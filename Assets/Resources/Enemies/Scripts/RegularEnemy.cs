using UnityEngine;
using System.Collections;

public class RegularEnemy: MonoBehaviour
{
    public GameObject PowerUpFab;
    public GameObject ExplosionFab;
    public static int Health;
    public static float Speed = 0;

	private Transform myTransform;
    private Vector3 position;
    private float Timer = 0f;
    private bool ExplosionDamage = false;

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

	// Collision detector...
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
            Destroy(this.gameObject);
        }

        //... with Player
        if(other.transform.tag == "Player" && Player.ShieldActive == false)
        {
            Player.PlayerScore -= 100;
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