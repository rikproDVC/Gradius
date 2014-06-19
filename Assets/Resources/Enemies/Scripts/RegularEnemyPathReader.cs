using UnityEngine;
using System.Collections;

public class RegularEnemyPathReader : MonoBehaviour {
	private Transform myTransform;
	
	//set variables for individual path keypoints
	public float angle;
	public float rotationSpeed;
	public Vector3 rotation;
	public float xMarker;
	public float yMarker;
	
	//set variables for determining path keypoints
    private bool newUpdate;
	private int pathNumber = 0;
	
	//make arrays for the path keypoints
	private float[] angles;
	private float[] rotationSpeeds;
	private string[] rotations;
	private float[] xMarkers;
	private float[] yMarkers;
    private float nullPath = 361;
	
	// Use this for initialization
	void Start () {
		//cache transform
		myTransform = transform;
		
		//fill the arrays with path keypoints
		angles = EnemySpawn.angles;
		rotations = EnemySpawn.rotations;
		xMarkers = EnemySpawn.xMarkers;
		yMarkers = EnemySpawn.yMarkers;
		rotationSpeeds = EnemySpawn.rotationSpeeds;
		
		//ask for new update to path keypoints
		newUpdate = true;
	}
	
	void Update()
	{
		//make the ship move
		//IF the ship does not need an update to path keypoints, do movement, ELSE ask for new path keypoints
		if (!newUpdate)
		{
			//make the ship move to path keypoint
			//IF the ship is at the correct x or y coordinate, ask for new update, ELSE move forward
			if (myTransform.position.x < xMarker + 0.5f && myTransform.position.x > xMarker - 0.5f || 
			    myTransform.position.y < yMarker + 0.5f && myTransform.position.y > yMarker - 0.5f)
			{
				newUpdate = true;
			}
			//make the ship rotate to ANGLE degrees
			//IF the ship does not need to rotate (nullPath = 361), ELSE rotate the ship to desired rotation in desired ROTATION
			if (angle == 361)
			{}
			else if (!(myTransform.rotation.eulerAngles.z < angle + 2f && myTransform.rotation.eulerAngles.z > angle - 2f))
			{
				myTransform.Rotate(rotation * rotationSpeed * Time.deltaTime);
			}
		}
		else
		{
			//ask for new path keypoints
			//IF the array for pathfinding has ran out, go 90 degrees straight forward, ELSE get new path keypoints
			if (angles.Length <= pathNumber)
			{
				angle = 90;
				xMarker = -21;
				yMarker = nullPath;
				newUpdate = false;
			}
			else
			{
				if (rotations[pathNumber] == "left")
				{
					rotation = Vector3.forward;
				}
				else if (rotations[pathNumber] == "right")
				{
					rotation = Vector3.back;
				}
				angle = angles[pathNumber];
				xMarker = xMarkers[pathNumber];
				yMarker = yMarkers[pathNumber];
				rotationSpeed = rotationSpeeds[pathNumber];
				pathNumber += 1;
				newUpdate = false;
			}
		}
	}
}