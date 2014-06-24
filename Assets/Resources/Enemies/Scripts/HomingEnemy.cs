using UnityEngine;
using System.Collections;

public class HomingEnemy : MonoBehaviour {
    //make variables for Gameobjects spawns; cache transform
    private Transform myTransform;
    public GameObject PowerUpFab;
    public GameObject ExplosionFab;
    
    //make variables for enemy attributes
    private int Health;
    private float Speed;
    private float timer;
    private float LaserTimer = 0;
    
    //make a vraible to get the enemy's position
    private Vector3 position;
    
    // Use this for initialization
    void Start()
    {
        //cache transform
        myTransform = transform;
        timer = Time.time;
        Speed = 6 + (Difficulty.homingEnemySpeedModifier);
        Health = Difficulty.homingEnemyHealth;
    }
	
    // Update is called once per frame
    void Update()
    {
        if (Time.time - timer > 0.1 && Speed < 10)
        {
            Speed += 0.5f;
            timer = Time.time;
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
        
        //... with Explosion
        if(other.transform.tag == "Explosion")
        {
            Health -= Rocket.AreaDamage;
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
            if(Time.time - LaserTimer > Laser.ROF)
            {
                Health -= Laser.Damage;
                LaserTimer = Time.time;
            }
        }
    }
}