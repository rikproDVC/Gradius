using UnityEngine;
using System.Collections;

public class Laser : MonoBehaviour {

	private Transform myTransform;
	public int currentSpeed = 20;

	private float LaserTimer;
	private float ChargeTimer;
	private Vector3 Position;

	// Use this for initialization
	void Start()
	{
		myTransform = transform;
		LaserTimer = 0f;
		ChargeTimer = 0f;
	}
	
	// Update is called once per frame
	void Update()
	{
		//Position compared to player position
		Position = Player.LaserPosition;
		myTransform.position = Position;

		//Timer to destroy
		if(Player.LaserCharge == 0)
		{
			Player.LaserActive = false;
			DestroyObject(this.gameObject);
		}
		if(Time.time - ChargeTimer > 0.05f && Player.LaserCharge > 0)
		{
			Player.LaserCharge -= 1;
			ChargeTimer = Time.time;
		}
	}
}
