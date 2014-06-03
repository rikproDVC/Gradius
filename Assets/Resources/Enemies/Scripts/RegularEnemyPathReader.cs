using UnityEngine;
using System.Collections;

public class RegularEnemyPathReader : MonoBehaviour {
	private Transform myTransform;

	//set variables for movement
	public float endMarker;
	private bool newUpdate;
	private float angle;
	private int pathNumber = 0;
	private float[] angles = new float[] {45, 135, 45, 135, 45, 135};
	private float[] endMarkers = new float[] {2f, -3f, 2f, -3f, 2f, -3f};

	// Use this for initialization
	void Start () {
		myTransform = transform;

		//set the angle the enemy has to travel at
		newUpdate = true;;

		//set the end marker of the path and the length of the path
		endMarker = -1f;
	}
	
	void Update()
	{
		if (!newUpdate)
		{
			//make the ship move to ENDMARKER y
				if (!(myTransform.position.y < endMarker + 0.5f && myTransform.position.y > endMarker - 0.5f))
				{
					myTransform.Translate (Vector3.up * RegularEnemy.enemySpeed * Time.deltaTime);
				}
				else
				{
					newUpdate = true;
				}
			//make the ship rotate to ANGLE degrees
			if (!(myTransform.rotation.eulerAngles.z < angle + 1f && myTransform.rotation.eulerAngles.z > angle - 1f))
			{
				if (myTransform.rotation.eulerAngles.z < angle)
				{
					myTransform.Rotate(Vector3.forward * 270 * Time.deltaTime);
				}
				else if (myTransform.rotation.eulerAngles.z > angle)
				{
					myTransform.Rotate(Vector3.back * 270 * Time.deltaTime);
				}
			}
		}
		else
		{
			angle = angles[pathNumber];
			endMarker = endMarkers[pathNumber];
			pathNumber += 1;
			newUpdate = false;
		}
	}
}