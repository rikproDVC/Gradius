using UnityEngine;
using System.Collections;

public class Enemy: MonoBehaviour
{
	private Transform MyTransform;
		// Use this for initialization
		void Start ()
		{
		MyTransform = transform;	
			
		}
	
		// Update is called once per frame
		void Update (){
				if (MyTransform.position.x < -30) {
					DestroyObject (this.gameObject);
				}
		}
	

		

	void  OnTriggerEnter2D(Collider2D otherCollider2D)
	{
				if (otherCollider2D.tag == "Player") {
						Destroy (this.gameObject);
			Player.PlayerScore += 100;
				} 
				
	}
	void OnCollisionEnter2D (Collision2D otherCollision2D)
		{
	

		if (otherCollision2D.transform.tag== "Bullet") {
						Destroy (this.gameObject);
			Player.PlayerScore += 100;
				} 
		}
		}

