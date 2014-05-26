using UnityEngine;
using System.Collections;

public class RegularEnemyPathReader : MonoBehaviour {
	private Transform myTransform;
	public static Vector3 targetLocation;
	
	// Use this for initialization
	void Start () {
		myTransform = transform;
	}
	
	// Update is called once per frame
	void Update () {
		myTransform.Translate(Vector3.up * RegularEnemy.enemySpeed * Time.deltaTime);

		if (targetLocation.y - myTransform.position.y > 0.01 || targetLocation.y - myTransform.position.y < 0.01)
		{
			if (myTransform.position.y < targetLocation.y)
			{
				myTransform.Rotate(Vector3.forward * 90 * Time.deltaTime);
			}
			else
		}
	}
}
