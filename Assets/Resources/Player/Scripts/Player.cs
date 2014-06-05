using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	//Player Related
	public float playerSpeed = 8;

	private Transform myTransform;

	//Weapon Related
	public GameObject BulletFab;
	public GameObject RocketFab;
	public GameObject LaserFab;

	public int PowerUp = 0;
	public int BulletCount_PowerUp = 0;
	public int RocketCount_PowerUp = 0;
	
	public Vector3 position;
	
	private float BulletTimer = 0f;
	private float RocketTimer = 0f;
	private float LaserTimer = 0f;
	private float ChargeTimer = 0f;

	public static Vector3 LaserPosition;
	public static float BulletROF;
	public static int LaserCharge = 100;
	public static bool LaserActive = false;
	public static int PlayerScore = 0;

	// Use this for initialization
	void Start()
	{
		myTransform = transform;
		myTransform.localScale = new Vector3(2, 2, 0);
	}
	
	// Update is called once per frame
	void Update()
	{
		//Move the player left and right
		myTransform.Translate (Vector3.right * playerSpeed * Input.GetAxis ("Horizontal") * Time.deltaTime);
		myTransform.Translate (Vector3.up * playerSpeed * Input.GetAxis ("Vertical") * Time.deltaTime);

		//Shoot Bullet
		if(Input.GetKey("space"))
		{
			//Standard bulletspeed
			BulletROF = 0.5f;

			//Powerups
			if(PowerUp == 0)
			{
				if(Time.time - BulletTimer > BulletROF)
				{
					position = new Vector3(myTransform.position.x + 0.5f, myTransform.position.y, myTransform.position.z);
					Instantiate(BulletFab, position, Quaternion.identity);
					BulletTimer = Time.time;
				}
			}
			if(PowerUp == 1)
			{
				BulletROF = 0.4f;
				if(Time.time - BulletTimer > BulletROF)
				{
					position = new Vector3(myTransform.position.x + 0.5f, myTransform.position.y, myTransform.position.z);
					Instantiate(BulletFab, position, Quaternion.identity);
					BulletTimer = Time.time;
				}
			}
			if(PowerUp == 2)
			{
				if(Time.time - BulletTimer > BulletROF)
				{
					position = new Vector3(myTransform.position.x + 0.5f, myTransform.position.y - 0.5f, myTransform.position.z);
					Instantiate(BulletFab, position, Quaternion.identity);
					position = new Vector3(myTransform.position.x + 0.5f, myTransform.position.y, myTransform.position.z);
					Instantiate(BulletFab, position, Quaternion.identity);
					position = new Vector3(myTransform.position.x + 0.5f, myTransform.position.y + 0.5f, myTransform.position.z);
					Instantiate(BulletFab, position, Quaternion.identity);
					BulletTimer = Time.time;
				}
			}
			if(PowerUp == 3)
			{
				if(Time.time - BulletTimer > BulletROF)
				{
					position = new Vector3(myTransform.position.x + 0.5f, myTransform.position.y - 0.5f, myTransform.position.z);
					Instantiate(BulletFab, position, Quaternion.Euler(0, 0, -30));
					position = new Vector3(myTransform.position.x + 0.5f, myTransform.position.y, myTransform.position.z);
					Instantiate(BulletFab, position, Quaternion.identity);
					position = new Vector3(myTransform.position.x + 0.5f, myTransform.position.y + 0.5f, myTransform.position.z);
					Instantiate(BulletFab, position, Quaternion.Euler(0, 0, 30));
					BulletTimer = Time.time;
				}
			}
			if(PowerUp == 4)
			{
				if(Time.time - BulletTimer > BulletROF)
				{
					position = new Vector3(myTransform.position.x + 0.5f, myTransform.position.y - 1f, myTransform.position.z);
					Instantiate(BulletFab, position, Quaternion.Euler(0, 0, -30));
					position = new Vector3(myTransform.position.x + 0.5f, myTransform.position.y - 0.5f , myTransform.position.z);
					Instantiate(BulletFab, position, Quaternion.Euler(0, 0, -15));
					position = new Vector3(myTransform.position.x + 0.5f, myTransform.position.y, myTransform.position.z);
					Instantiate(BulletFab, position, Quaternion.identity);
					position = new Vector3(myTransform.position.x + 0.5f, myTransform.position.y + 0.5f, myTransform.position.z);
					Instantiate(BulletFab, position, Quaternion.Euler(0, 0, 15));
					position = new Vector3(myTransform.position.x + 0.5f, myTransform.position.y + 1, myTransform.position.z);
					Instantiate(BulletFab, position, Quaternion.Euler(0, 0, 30));
					BulletTimer = Time.time;
				}
			}
		}

		//Shoot Rocket
		if(Input.GetKey("."))
		{
			if(Time.time - RocketTimer > 0.5F)
			{
				position = new Vector3(myTransform.position.x + 0.5f, myTransform.position.y, myTransform.position.z);
				Instantiate(RocketFab, position, Quaternion.identity);
				RocketTimer = Time.time;
			}
		}

		//Shoot Laser
		if(Input.GetKeyDown(",") && LaserCharge == 100)
		{
			position = new Vector3(myTransform.position.x + 5.4f, myTransform.position.y, myTransform.position.z);
			Instantiate(LaserFab, position, Quaternion.identity);
			LaserActive = true;
		}
		LaserPosition = new Vector3(myTransform.position.x + 5.4f, myTransform.position.y, myTransform.position.z);

		if(LaserActive == false && LaserCharge < 100)
		{
			if(Time.time - ChargeTimer > 15f)
			{
				if(Time.time - LaserTimer > 0.2f)
				{
					LaserCharge += 1;
					LaserTimer = Time.time;
				}
			}

		}
	}

	void  OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Powerup")
		{
			PowerUp = 1;
		} 
		
	}
}
