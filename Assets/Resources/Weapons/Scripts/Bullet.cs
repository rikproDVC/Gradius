using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	private Transform myTransform;
	public int currentSpeed = 20;

	// Use this for initialization
	void Start()
	{
		myTransform = transform;
	}
	
	// Update is called once per frame
	void Update()
	{
		myTransform.Translate(Vector3.right * currentSpeed * Time.deltaTime);

		if (myTransform.position.x > 15)
		{
			DestroyObject(this.gameObject);
		}
	}
}
