using UnityEngine;
using System.Collections;

public class RegularEnemyPathReader : MonoBehaviour {
	private Transform myTransform;

	//set variables for movement
	public float angle;
	public float xMarker;
	public float yMarker;

	private bool newUpdate;
	private int pathNumber = 0;
	private float nullPath = 361;

	private float[] angles;
	private float[] xMarkers;
	private float[] yMarkers;


	// Use this for initialization
	void Start () {
		myTransform = transform;

		angles = new float[] {45, 135, 45, 135, 45, 135};
		xMarkers = new float[] {nullPath, nullPath, nullPath, nullPath, nullPath, nullPath};
		yMarkers = new float[] {2, -3, 2, -3, 2, -3};

		//set the angle the enemy has to travel at
		newUpdate = true;
	}
	
	void Update()
	{
		if (!newUpdate)
		{
			//make the ship move to ENDMARKER x or y
			if (myTransform.position.x < xMarker + 0.5f && myTransform.position.x > xMarker - 0.5f || 
			myTransform.position.y < yMarker + 0.5f && myTransform.position.y > yMarker - 0.5f)
			{
				newUpdate = true;
			}
			else
			{
				myTransform.Translate (Vector3.up * RegularEnemy.enemySpeed * Time.deltaTime);
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
			if (angles.Length <= pathNumber)
			{
				angle = 90;
				xMarker = -21;
				yMarker = nullPath;
				newUpdate = false;
			}
			else
			{
				angle = angles[pathNumber];
				xMarker = xMarkers[pathNumber];
				yMarker = yMarkers[pathNumber];
				pathNumber += 1;
				newUpdate = false;
			}
		}
	}
}