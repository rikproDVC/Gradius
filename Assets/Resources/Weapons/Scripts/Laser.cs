using UnityEngine;
using System.Collections;

public class Laser : MonoBehaviour {

	public static float ROF = 0.3f;
	public static float ConsumeRate = 0.01f;
	public static int Damage = 1;

	private float ConsumeTimer = 0f;
	private Transform myTransform;
	private Vector3 Position;

	// Use this for initialization
	void Start()
	{
		myTransform = transform;
	}
	
	// Update is called once per frame
	void Update()
	{
		//Laser position in relation to player position
		Position = Player.PlayerPositionLaser;
		myTransform.position = Position;

		//Consume charge
		if(Time.time - ConsumeTimer > ConsumeRate)
		{
			LaserPU.LaserCharge -= 1;
			ConsumeTimer = Time.time;
		}

		//Destroy laser
		if(LaserPU.LaserCharge == 0)
		{
			LaserPU.PauseTimer = Time.time;
			Destroy(this.gameObject);
		}
	}
}
