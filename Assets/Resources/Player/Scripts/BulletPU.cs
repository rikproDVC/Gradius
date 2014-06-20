using UnityEngine;
using System.Collections;

public class BulletPU : MonoBehaviour {

	public static int PowerLevel = 0;
	public GameObject BulletFab;
    public GameObject BulletAudioFab;

	private Transform myTransform;
	private float ROF = 0.5f;
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
		//Shoot Bullet
		if(Input.GetKey("space"))
		{
			//PowerUp
			if(Time.time - Timer > ROF)
			{
				if(PowerLevel >= 0)
				{
					position = new Vector3(myTransform.position.x + 0.5f, myTransform.position.y, myTransform.position.z);
					Instantiate(BulletFab, position, Quaternion.identity);
                    Instantiate(BulletAudioFab, position, Quaternion.identity);
				}
				if(PowerLevel >= 1)
				{
					position = new Vector3(myTransform.position.x + 0.5f, myTransform.position.y - 0.5f, myTransform.position.z);
					Instantiate(BulletFab, position, Quaternion.Euler(0, 0, -15));
					position = new Vector3(myTransform.position.x + 0.5f, myTransform.position.y + 0.5f, myTransform.position.z);
					Instantiate(BulletFab, position, Quaternion.Euler(0, 0, 15));
				}
				if(PowerLevel >= 2)
				{
					position = new Vector3(myTransform.position.x + 0.5f, myTransform.position.y - 0.5f , myTransform.position.z);
					Instantiate(BulletFab, position, Quaternion.Euler(0, 0, -30));
					position = new Vector3(myTransform.position.x + 0.5f, myTransform.position.y + 0.5f, myTransform.position.z);
					Instantiate(BulletFab, position, Quaternion.Euler(0, 0, 30));
				}
				if(PowerLevel >= 3)
				{
					position = new Vector3(myTransform.position.x + 0.5f, myTransform.position.y - 0.5f , myTransform.position.z);
					Instantiate(BulletFab, position, Quaternion.Euler(0, 0, -45));
					position = new Vector3(myTransform.position.x + 0.5f, myTransform.position.y + 0.5f, myTransform.position.z);
					Instantiate(BulletFab, position, Quaternion.Euler(0, 0, 45));
				}
				if(PowerLevel == 4)
				{
					position = new Vector3(myTransform.position.x + 0.5f, myTransform.position.y - 0.5f , myTransform.position.z);
					Instantiate(BulletFab, position, Quaternion.Euler(0, 0, -60));
					position = new Vector3(myTransform.position.x + 0.5f, myTransform.position.y + 0.5f, myTransform.position.z);
					Instantiate(BulletFab, position, Quaternion.Euler(0, 0, 60));
				}
				Timer = Time.time;
			}
		}
	}
}
