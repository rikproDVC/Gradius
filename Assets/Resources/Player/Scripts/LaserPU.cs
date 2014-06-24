using UnityEngine;
using System.Collections;

public class LaserPU : MonoBehaviour {
	
	public static int PowerLevel = 0;
	public static int LaserCharge = 100;
	public GameObject LaserFab;
    public GameObject LaserAudioFab;
	public static float PauseTimer = 0f;
    public static bool LaserActive = false;

	private Transform myTransform;
	private Vector3 position;
	private float RechargeTimer = 0f;
	private float RechargeRate = 1f;
	
	// Use this for initialization
	void Start ()
	{
		myTransform = transform;
	}
	
	// Update is called once per frame
	void Update ()
	{
		//Shoot Laser
        if(Input.GetKeyDown(",") && LaserCharge == 100 && LaserActive == false  && pause.paused==false)
		{
			//Instatiate
			position = new Vector3(myTransform.position.x + 5.4f, myTransform.position.y, myTransform.position.z);
			Instantiate(LaserFab, position, Quaternion.identity);
            Instantiate(LaserAudioFab, position, Quaternion.identity);
			LaserActive = true;

			//Charge + Damage
			if(PowerLevel >= 1)
			{
				Laser.ROF = 0.2f;
				RechargeRate = 0.75f;
                Instantiate(LaserAudioFab, position, Quaternion.identity);
			}
			if(PowerLevel >= 2)
			{
				Laser.ConsumeRate = 0.05f;
			}
			if(PowerLevel >= 3)
			{
				Laser.ROF = 0.1f;
				RechargeRate = 0.5f;
			}
			if(PowerLevel == 4)
			{
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
