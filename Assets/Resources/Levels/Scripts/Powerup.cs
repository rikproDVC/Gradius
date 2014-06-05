using UnityEngine;
using System.Collections;

public class Powerup : MonoBehaviour {
	private Transform MyTransform;
	// Use this for initialization
	void Start () {
		MyTransform = transform;	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (MyTransform.position.x < -30)
		{
			DestroyObject(this.gameObject);
		}
	}

	void  OnTriggerEnter2D(Collider2D otherCollider2D)
	{
		if (otherCollider2D.tag == "Player") {
			Player.PowerUp+=1;
			Destroy(this.gameObject);

		} 

	}

}

