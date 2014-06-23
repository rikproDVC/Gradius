using UnityEngine;
using System.Collections;

public class HomingEnemy : MonoBehaviour {
    //make variables for Gameobjects spawns; cache transform
    private Transform myTransform;
    public GameObject PowerUpFab;
    public GameObject ExplosionFab;
    
    //make variables for enemy attributes
    public static int baseHealth;
    public static int Health;
    public static float baseSpeed;
    public static float Speed;
    
    //make a vraible to get the enemy's position
    private Vector3 position;
    
    // Use this for initialization
    void Start()
    {
        //cache transform
        myTransform = transform;

        baseHealth = 7;
        baseSpeed = 6;
        Health = baseHealth;
        Speed = baseSpeed;
    }
	
    // Update is called once per frame
    void Update()
    {

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
        if (other.transform.tag == "Bullet")
        {
            Health -= Bullet.Damage;
        }
        
        //... with Rocket
        if (other.transform.tag == "Rocket")
        {
            Health -= Rocket.ImpactDamage;
        }
    }
}