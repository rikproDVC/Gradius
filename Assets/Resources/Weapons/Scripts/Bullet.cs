using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	private Transform myTransform;
	public int BulletSpeed = 20;

	// Use this for initialization
	void Start()
	{
		myTransform = transform;
	}
	
	// Update is called once per frame
	void Update()
	{
		myTransform.Translate(Vector3.right * BulletSpeed * Time.deltaTime);

		if (myTransform.position.x > 15)
		{
			DestroyObject(this.gameObject);
		}
	}

	// Collision stuff
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.transform.tag == "Enemy")
		{
			Destroy(this.gameObject);
		}
	}
}
