using UnityEngine;
using System.Collections;

public class LaserPU : MonoBehaviour {
	
	public static int PowerLevel = 4;
	public static int LaserCharge = 100;
	public GameObject LaserFab;
	public static float PauseTimer = 0f;

	private Transform myTransform;
	private Vector3 position;
	private float RechargeTimer = 0f;
	private float RechargeRate = 1f;
	private bool LaserActive = false;
	
	// Use this for initialization
	void Start ()
	{
		myTransform = transform;
	}
	
	// Update is called once per frame
	void Update ()
	{
		//Shoot Laser
		if(Input.GetKeyDown(",") && LaserCharge == 100 && LaserActive == false)
		{
			//Instatiate
				position = new Vector3(myTransform.position.x + 5.4f, myTransform.position.y, myTransform.position.z);
				Instantiate(LaserFab, position, Quaternion.identity);
				LaserActive = true;

			//Charge + Damage
			if(PowerLevel >= 1)
			{
				Laser.ROF = 0.75f;
				RechargeRate = 0.75f;
			}
			if(PowerLevel >= 2)
			{
				Laser.Damage = 2;
				Laser.ConsumeRate = 0.05f;
			}
			if(PowerLevel >= 3)
			{
				Laser.ROF = 0.5f;
				RechargeRate = 0.5f;
			}
			if(PowerLevel == 4)
			{
				Laser.Damage = 4;
				Laser.ConsumeRate = 0.1f;
			}
		}

		//Pause before Recharge
		if(LaserCharge == 0)
		{
			if(Time.time - PauseTimer > 15f)
			{
				LaserActive = false;
			}
		}

		//Recharging
		if(LaserActive == false && LaserCharge < 100)
		{
			if(Time.time - RechargeTimer > RechargeRate)
			{
				LaserCharge += 1;
				RechargeTimer = Time.time;
			}
		}
	}
}
