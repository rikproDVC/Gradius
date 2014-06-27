using UnityEngine;
using System.Collections;

public class HomingEnemy : MonoBehaviour {
    //make variables for Gameobjects spawns; cache transform
    private Transform myTransform;
    public GameObject PowerUpFab;
    public GameObject ExplosionFab;

    //make variables for damage values
    private Vector3 position;
    private float Timer = 0f;
    private bool ExplosionDamage = false;

    //make variables for enemy attributes
    private int Health;
    private float Speed;
    private float speedIncreaseTimer;

    //Get the wave number to get the difficulty level
    private int stageForHomingEnemyHealth = EnemySpawn.wave;
    private int stageForSpeedModifier = EnemySpawn.wave;
    
    // make variables for setting health and speed variables in enemies
    private int homingEnemyHealthModifier;
    private float homingEnemySpeedModifier;

    
    // Use this for initialization
    void Start()
    {
        //cache transform
        myTransform = transform;

        if (stageForHomingEnemyHealth > 100)
        {
            homingEnemyHealthModifier += 4;
            stageForHomingEnemyHealth -= 10;
        }
        if (stageForHomingEnemyHealth > 80)
        {
            homingEnemyHealthModifier += 4;
            stageForHomingEnemyHealth -= 10;
        }
        if (stageForHomingEnemyHealth > 60)
        {
            homingEnemyHealthModifier += 4;
            stageForHomingEnemyHealth -= 10;
        }
        if (stageForHomingEnemyHealth > 40)
        {
            homingEnemyHealthModifier += 4;
            stageForHomingEnemyHealth -= 10;
        }
        if (stageForHomingEnemyHealth > 20)
        {
            homingEnemyHealthModifier += 4;
            stageForHomingEnemyHealth -= 10;
        }

        speedIncreaseTimer = Time.time;
        homingEnemySpeedModifier = stageForSpeedModifier / 10;
        Speed = 6 + homingEnemySpeedModifier;
        Health = 4 + homingEnemyHealthModifier;
    }
	
    // Update is called once per frame
    void Update()
    {
        if (Time.time - speedIncreaseTimer > 0.1 && Speed < 10)
        {
            Speed += 0.5f;
            speedIncreaseTimer = Time.time;
        }

        myTransform.Translate (Vector3.up * Speed * Time.deltaTime);
        if (myTransform.position.x < General.leftBorder || myTransform.position.x > General.rightBorder)
        {
            Destroy(this.gameObject);
        }
        
        if (Health <= 0)
        {
            Player.PlayerScore += 100;
            if(Random.Range(1, 5) == 1)
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