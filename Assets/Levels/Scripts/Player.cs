using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{

		private Transform MyTransform;
		public GameObject Bullet;
		public GameObject Rocket;
		public int PlayerSpeed = 5;
		public static int PlayerScore = 0;
		public float BulletRate = 0.5F;
		public float RocketRate = 0.1F;
		private float nextFire = 0.0F;
		public int Weapon = 0;
		


		// Use this for initialization
		void Start ()
		{
			

				MyTransform = transform;
				//spawn point		 x	y	z
				// position to be at -3 -3 -1

		MyTransform.position = new Vector3 (-3,-3,1);



		}
	
		// Update is called once per frame
		void Update ()
		{
		Debug.Log (PlayerScore);
				//move player left and right
				MyTransform.Translate (Vector3.right * PlayerSpeed * Input.GetAxis ("Vertical") * Time.deltaTime);
				//move player up and down
				MyTransform.Translate (Vector3.down * PlayerSpeed * Input.GetAxis ("Horizontal") * Time.deltaTime);

				
				//Space is pressed and fire () is called				
				if (Input.GetKey ("space") && renderer.enabled == true && Time.time > nextFire) {
						
						if (Weapon == 0) {
						nextFire = Time.time + BulletRate;
								fire ();
						}
						if (Weapon == 1) {
						nextFire = Time.time + RocketRate;
								fire2 ();
						}
				}
			}

		void fire ()
		{
				//Fire the lazerzzzzz!!!!!
				//If the player presses the spacebar, the lazerzzzzz!!!!! will fire
	
				// Set position for lazer
				Vector3 position = new Vector3 (MyTransform.position.x +1 , MyTransform.position.y, MyTransform.position.z);
				// Fire lazer
				Instantiate (Bullet, position, Quaternion.Euler (0, 0, -90));
	

		}
				void fire2 ()
			{
			//Fire the lazerzzzzz!!!!!
			//If the player presses the spacebar, the lazerzzzzz!!!!! will fire
		
			// Set position for rocket
			Vector3 position = new Vector3 (MyTransform.position.x +1 , MyTransform.position.y, MyTransform.position.z);
			// Fire rocket
			Instantiate (Rocket, position, Quaternion.Euler (0, 0, 0));
		
		
	}

	void  OnTriggerEnter2D(Collider2D otherCollider2D)
	{
		if (otherCollider2D.tag == "Powerup") {

			PlayerSpeed=8;
			BulletRate=0.25f;
		} 

	}

}
