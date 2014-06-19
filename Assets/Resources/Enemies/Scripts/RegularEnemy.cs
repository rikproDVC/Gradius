using UnityEngine;
using System.Collections;

public class RegularEnemy: MonoBehaviour
{
	public static float enemySpeed = 3;
    public GameObject PowerUpFab;

<<<<<<< HEAD
    private Vector3 position;
	private int Health = 12;
	private Transform MyTransform;
	private float enemySpeed = EnemySpawn.enemySpeed;
=======
	private int Health = 12;
	private Transform MyTransform;
>>>>>>> 2b3b102f9021b524f017fff331b029eb21cc87f1
	
	// Use this for initialization
	void Start()
	{
		MyTransform = transform;
	}
	
	// Update is called once per frame
	void Update()
	{
<<<<<<< HEAD
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
                position = new Vector3(MyTransform.position.x, MyTransform.position.y, MyTransform.position.z);
=======
        if (Health < 1)
        {
            Player.PlayerScore += 100;
            if(Random.Range(1, 25) == 1)
            {
                Vector3 position = new Vector3(MyTransform.position.x, MyTransform.position.y, MyTransform.position.z);
>>>>>>> 2b3b102f9021b524f017fff331b029eb21cc87f1
                Instantiate(PowerUpFab, position, Quaternion.identity);
            }
            Destroy(this.gameObject);
        }
       
        if (!renderer.IsVisibleFrom(Camera.main))
        {
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