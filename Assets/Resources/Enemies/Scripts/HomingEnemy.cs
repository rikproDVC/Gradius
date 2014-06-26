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
    private float LaserTimer = 0;

    
    // Use this for initialization
    void Start()
    {
        //cache transform
        myTransform = transform;
        speedIncreaseTimer = Time.time;
        Speed = 6 + Difficulty.homingEnemySpeedModifier;
        Health = 4 + Difficulty.homingEnemyHealthModifier;
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