using UnityEngine;
using System.Collections;

public class RegularEnemyPathReader : MonoBehaviour {
	private Transform myTransform;
	public static Vector3 targetLocation;
	
	// Use this for initialization
	void Start () {
		myTransform = transform;
		int X = -4;
		int Y = -2;
		targetLocation = new Vector3(X, Y, 0);
	}
	
	// Update is called once per frame
	void Update () {
		//if the desired location of the enemy is more than 0.1 away, go towards the position
		//if the enemy is less than 0.1 away, set a new position
		if (targetLocation.x - myTransform.position.x > 0.01 && targetLocation.y - myTransform.position.y > 0.01)
		{
			//if the X position is of the enemy is lower than the desired position, go towards the right(+x)
			//if the x position is higher than the desired position, go towards the left(-x)
			if (myTransform.position.x < targetLocation.x)
			{
				myTransform.Translate(Vector3.right * RegularEnemy.enemySpeed * Time.deltaTime);
			}
			else if (myTransform.position.x > targetLocation.x)
			{
				myTransform.Translate(Vector3.left * RegularEnemy.enemySpeed * Time.deltaTime);
			}

			if (myTransform.position.y < targetLocation.y)
			{
				myTransform.Translate(Vector3.up * RegularEnemy.enemySpeed * Time.deltaTime);
			}
			else if (myTransform.position.y > targetLocation.y)
			{
				myTransform.Translate(Vector3.down * RegularEnemy.enemySpeed * Time.deltaTime);
			}
		}
		else
		{
			float X = 4;
			float Y = 2;
			targetLocation = new Vector3(X, Y, 0);
		}

		Debug.Log ("X" + (targetLocation.x - myTransform.position.x));
		Debug.Log ("Y" + (targetLocation.y - myTransform.position.y));
	}
}
