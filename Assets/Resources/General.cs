using UnityEngine;
using System.Collections;

public class General : MonoBehaviour {

	public GameObject BulletFab;
	public GameObject RocketFab;
	public GameObject LaserFab;

	public int PowerUp = 0;

	public Vector3 position;

	private float BulletTimer = 0f;
	private float RocketTimer = 0f;
	private float LaserTimer = 0f;

	private bool LaserActive = false;

	// Use this for initialization
	void Start()
	{
			
	}
	
	// Update is called once per frame
	void Update()
	{
		if(Input.GetKey("space"))
		{
			if(PowerUp == 0)
			{
				if(Time.time - BulletTimer > 0.2f)
				{
					position = new Vector3(0, 0, 0);
					Instantiate(BulletFab, position, Quaternion.identity);
					BulletTimer = Time.time;
				}
			}
			if(PowerUp == 1)
			{
				if(Time.time - BulletTimer > 0.2F)
				{
					position = new Vector3(0, 0.5f, 0);
					Instantiate(BulletFab, position, Quaternion.identity);
					position = new Vector3(0, -0.5f, 0);
					Instantiate(BulletFab, position, Quaternion.identity);
					BulletTimer = Time.time;
				}
			}
			if(PowerUp == 2)
			{
				if(Time.time - BulletTimer > 0.2F)
				{
					position = new Vector3(0, 0, 0);
					Instantiate(BulletFab, position, Quaternion.identity);
					position = new Vector3(0, 0.5f, 0);
					Instantiate(BulletFab, position, Quaternion.identity);
					position = new Vector3(0, -0.5f, 0);
					Instantiate(BulletFab, position, Quaternion.identity);
					BulletTimer = Time.time;
				}
			}
			if(PowerUp == 3)
			{
				if(Time.time - BulletTimer > 0.2F)
				{
					position = new Vector3(0, 0, 0);
					Instantiate(BulletFab, position, Quaternion.identity);
					position = new Vector3(0, 0.5f, 0);
					Instantiate(BulletFab, position, Quaternion.Euler(0, 0, 30));
					position = new Vector3(0, -0.5f, 0);
					Instantiate(BulletFab, position, Quaternion.Euler(0, 0, -30));
					BulletTimer = Time.time;
				}
			}
			if(PowerUp == 4)
			{
				if(Time.time - BulletTimer > 0.2F)
				{
					position = new Vector3(0, 0, 0);
					Instantiate(BulletFab, position, Quaternion.identity);
					position = new Vector3(0, 0.5f, 0);
					Instantiate(BulletFab, position, Quaternion.Euler(0, 0, 30));
					position = new Vector3(0, -0.5f, 0);
					Instantiate(BulletFab, position, Quaternion.Euler(0, 0, -30));
					position = new Vector3(0, 0.5f, 0);
					Instantiate(BulletFab, position, Quaternion.Euler(0, 0, 15));
					position = new Vector3(0, -0.5f, 0);
					Instantiate(BulletFab, position, Quaternion.Euler(0, 0, -15));
					BulletTimer = Time.time;
				}
			}
		}

		if(Input.GetKey("."))
		{
			if(Time.time - RocketTimer > 0.5F)
			{
				position = new Vector3(0, 1, 0);
				Instantiate(RocketFab, position, Quaternion.identity);
				RocketTimer = Time.time;
			}
		}

		if(Input.GetKeyDown(","))
		{
			position = new Vector3(0, 2, 0);
			Instantiate(LaserFab, position, Quaternion.identity);
		}
	}
}
