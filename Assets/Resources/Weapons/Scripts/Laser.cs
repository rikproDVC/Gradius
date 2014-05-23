using UnityEngine;
using System.Collections;

public class Laser : MonoBehaviour {

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
		//myTransform.position = Player.position
		if(Input.GetKeyUp(","))
		{
			DestroyObject(this.gameObject);
		}
	}
}
