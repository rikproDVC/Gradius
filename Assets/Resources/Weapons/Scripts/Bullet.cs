using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public static int Damage = 4;

	private Transform myTransform;
	private int Speed = 20;

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
			DestroyObject(this.gameObject);
		}
	}

	// Collision with enemy
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.transform.tag == "Enemy")
		{
			Destroy(this.gameObject);
		}
	}
}
