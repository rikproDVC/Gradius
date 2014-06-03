using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour 
{

	private Transform MyTransform;
	public int BulletSpeed = 5;


	// Use this for initialization
	void Start () {
	
		MyTransform = transform;		
	}
	
	// Update is called once per frame
	void Update ()
	{
			//Make the lazer shoot out and go to the right (it says up but its right)
		MyTransform.Translate(Vector3.up * BulletSpeed * Time.deltaTime);
		// destroy gameobject if position is bigger then 18
		if (MyTransform.position.x > 19)
		{
			DestroyObject(this.gameObject);
		}
	}
}