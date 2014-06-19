using UnityEngine;
using System.Collections;

public class PowerUp : MonoBehaviour {

    private string[] TypeArray = new string[12] {"Bullet", "Rocket", "Laser", "PlayerSpeed", "PlayerLive", "PlayerLive", "RocketAmmo", "RocketAmmo", "RocketAmmo", "Shield", "Shield", "Shield"};
    private int TypeNum;
	public string Type;
    private int Speed = 5;
    private Transform myTransform;

	// Use this for initialization
	void Start ()
	{
        TypeNum = Random.Range(0, 12);
		Type = TypeArray[TypeNum];
        myTransform = transform;
	}
	
	// Update is called once per frame
	void Update ()
	{
        if (!renderer.IsVisibleFrom(Camera.main))
        {
            Destroy(this.gameObject);
        }
        myTransform.Translate(Vector3.left * Speed * Time.deltaTime);
	}

	// Collision Detector
	void  OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player")
		{
			if (Type == "Bullet" && BulletPU.PowerLevel < 4)
			{
				BulletPU.PowerLevel += 1;
			}
			if (Type == "Rocket" && RocketPU.PowerLevel < 4)
			{
				RocketPU.PowerLevel += 1;
			}
			if (Type == "Laser" && LaserPU.PowerLevel < 4)
			{
				LaserPU.PowerLevel += 1;
			}
            if (Type == "PlayerSpeed" && Player.PowerLevel < 4)
            {
                Player.PowerLevel += 1;
            }
            if (Type == "PlayerLive")
            {
                Player.PlayerLives += 1;
            }
            if (Type == "RocketAmmo")
            {
                RocketPU.RocketAmmo += 5;
            }
            if (Type == "Shield")
            {
                Player.Shield += 1;
            }

			Player.PlayerScore += 50;
			Destroy(this.gameObject);
		}
	}
}
