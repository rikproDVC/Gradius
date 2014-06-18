using UnityEngine;
using System.Collections;

public class RegularEnemy: MonoBehaviour
{
	private Transform myTransform;
    public GameObject PowerUpFab;
    public GameObject ExplosionFab;

<<<<<<< HEAD
    private Vector3 position;
	private int Health = 12;
	private Transform MyTransform;
=======
	private float enemySpeed = EnemySpawn.enemySpeed;
	private int Health = 6;

>>>>>>> 52b33c8dd3d6cf8236aaac8e153695a391f16082
	
	// Use this for initialization
	void Start()
	{
		myTransform = transform;
	}
	
	// Update is called once per frame
	void Update()
	{
		myTransform.Translate (Vector3.up * enemySpeed * Time.deltaTime);
		if (myTransform.position.x < -20)
		{
			Destroy(this.gameObject);
		}

		if (Health <= 0)
		{
			Player.PlayerScore += 100;
			if(Random.Range(1, 5) == 1)
			{
<<<<<<< HEAD
                position = new Vector3(MyTransform.position.x, MyTransform.position.y, MyTransform.position.z);
=======
                Vector3 position = new Vector3(myTransform.position.x, myTransform.position.y, myTransform.position.z);
>>>>>>> 52b33c8dd3d6cf8236aaac8e153695a391f16082
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