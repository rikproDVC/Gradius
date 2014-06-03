using UnityEngine;
using System.Collections;

public class Rocket : MonoBehaviour 
{
	
	private Transform MyTransform;
	public int RocketSpeed = 5;
	
	
	// Use this for initialization
	void Start () {
		
		MyTransform = transform;		
	}
	
	// Update is called once per frame
	void Update ()
	{
		//Make the lazer shoot out and go to the right (it says up but its right)
		MyTransform.Translate(Vector3.right * RocketSpeed * Time.deltaTime);
		// destroy gameobject if position is bigger then 18
		if (MyTransform.position.x > 18)
		{
			DestroyObject(this.gameObject);
		}
	}
}