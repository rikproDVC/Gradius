using UnityEngine;
using System.Collections;

public class RegularEnemy: MonoBehaviour
{
	private Transform myTransform;
    public GameObject PowerUpFab;
    public GameObject ExplosionFab;

    private Vector3 position;
<<<<<<< HEAD
	private int Health = 2;

=======
<<<<<<< HEAD
	private int Health = 4;
	private Transform MyTransform;
=======
	private int Health = 2;
>>>>>>> e02682a2534dce4d71724adbaa92d7957ae473b9
>>>>>>> d1ebb38174dc4f5e4baeac74a2110d2f69c0df6a
	private float enemySpeed = EnemySpawn.enemySpeed;
	
	// Use this for initialization
	void Start()
	{
		myTransform = transform;
	}
	
	// Update is called once per frame
	void Update()
	{
		myTransform.Translate (Vector3.up * enemySpeed * Time.deltaTime);
<<<<<<< HEAD
        if (myTransform.position.x < -20)
        {
            Destroy(this.gameObject);
        }
=======
        if (myTransform.position.x < General.leftBorder || myTransform.position.x > General.rightBorder)
		{
			Destroy(this.gameObject);
		}
>>>>>>> d1ebb38174dc4f5e4baeac74a2110d2f69c0df6a

		if (Health <= 0)
		{
			Player.PlayerScore += 100;
            position = new Vector3(myTransform.position.x, myTransform.position.y, myTransform.position.z);   
                                       
			if(Random.Range(1, 5) == 1)
			{
<<<<<<< HEAD
                position = new Vector3(myTransform.position.x, myTransform.position.y, myTransform.position.z);   
=======
                position = new Vector3(myTransform.position.x, myTransform.position.y, myTransform.position.z);
>>>>>>> d1ebb38174dc4f5e4baeac74a2110d2f69c0df6a
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
//		if(other.transform.tag == "Explosion")
//		{
//			Health -= Rocket.AreaDamage;
//		}

		//... with Laser
//		if(other.transform.tag == "Laser")
//		{
//			Health -= Laser.Damage;
//		}
	}
}