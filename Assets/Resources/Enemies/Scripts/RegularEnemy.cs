﻿using UnityEngine;
using System.Collections;

public class RegularEnemy : MonoBehaviour {
	private Transform myTransform;
	public static float enemySpeed = 3;

	// Use this for initialization
	void Start()
	{
		myTransform = transform;
	}
	
	// Update is called once per frame
	void Update()
	{

	}

	// Collision stuff
	void OnCollisionEnter2D(Collision2D collider)
	{
		Debug.Log("TEST TEST TEST TEST");
		if(collider.transform.tag == "Bullet")
		{
			Destroy(this.gameObject);
		}
		if(collider.transform.tag == "Player")
		{
			Destroy(this.gameObject);
		}
	}
}
