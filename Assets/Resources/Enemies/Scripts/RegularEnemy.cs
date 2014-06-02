using UnityEngine;
using System.Collections;

public class RegularEnemy : MonoBehaviour {
	private Transform myTransform;
	public static float enemySpeed = 10;

	// Use this for initialization
	void Start()
	{
		myTransform = transform;
	}
	
	// Update is called once per frame
	void Update()
	{
		myTransform.Translate(Vector3.left * enemySpeed * Time.deltaTime);
	}

	// Collision stuff
	void OnTriggerEnter(Collider collider)
	{
		if(collider.gameObject.CompareTag("Bullet"))
		{
			Destroy(this.gameObject);
		}
	}
}
