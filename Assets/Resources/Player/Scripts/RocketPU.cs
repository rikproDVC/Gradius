using UnityEngine;
using System.Collections;

public class RocketPU : MonoBehaviour {
	
	public static int PowerLevel = 4;
	public GameObject RocketFab;

	private Transform myTransform;
	private float ROF;
	private float Timer = 0f;
	private Vector3 position;
	
	// Use this for initialization
	void Start ()
	{
		myTransform = transform;
	}
	
	// Update is called once per frame
	void Update ()
	{
		//Shoot Rocket
		if(Input.GetKey("."))
		{
			//ROF + Damage
			if(PowerLevel == 0)
			{
				ROF = 1f;
			}
			if(PowerLevel >= 1)
			{
				ROF = 0.9f;
				Rocket.ImpactDamage = 4;
			}
			if(PowerLevel >= 2)
			{
				ROF = 0.8f;
				Rocket.AreaDamage = 4;
			}
			if(PowerLevel >= 3)
			{
				ROF = 0.7f;
				Rocket.ImpactDamage = 6;
			}
			if(PowerLevel >= 4)
			{
				ROF = 0.6f;
				Rocket.AreaDamage = 6;
			}

			//PowerUp
			if(Time.time - Timer > ROF)
			{
				if(PowerLevel >= 0)
				{
					position = new Vector3(myTransform.position.x + 0.5f, myTransform.position.y, myTransform.position.z);
					Instantiate(RocketFab, position, Quaternion.identity);
				}
				if(PowerLevel >= 1)
				{
					if(Time.time - Timer > ROF)
					{
						position = new Vector3(myTransform.position.x + 0.5f, myTransform.position.y - 0.5f, myTransform.position.z);
						Instantiate(RocketFab, position, Quaternion.Euler(0, 0, -80));
						position = new Vector3(myTransform.position.x + 0.5f, myTransform.position.y + 0.5f, myTransform.position.z);
						Instantiate(RocketFab, position, Quaternion.Euler(0, 0, 80));
						Timer = Time.time;
					}
				}
				Timer = Time.time;
			}
		}
	}
}
