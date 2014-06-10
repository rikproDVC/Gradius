using UnityEngine;
using System.Collections;

public class Rocket : MonoBehaviour
{
	public static int ImpactDamage = 2;
	public static int AreaDamage = 2;

	private Transform myTransform;
	private int Speed = 7;

	// Use this for initialization
	void Start()
	{
		myTransform = transform;
	}
	
	// Update is called once per frame
	void Update()
	{
		myTransform.Translate(Vector3.right * Speed * Time.deltaTime);

		if (myTransform.position.x > 15)
		{
			Destroy(this.gameObject);
		}
	}

	// Collision with enemy
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.transform.tag == "Enemy")
		{
			//SPAWN EXPLOSION !!!!!
			Destroy(this.gameObject);
		}
	}
}
