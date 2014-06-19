using UnityEngine;
using System.Collections;

public class EnemySpawn : MonoBehaviour {
    //make variables for spawning the enemy
    public GameObject RegularEnemy;
    private Vector3 position;

    //make arrays for enemy path keypoints
    public static float enemySpeed;
    public static float[] angles;
    public static float[] rotationSpeeds;
    public static string[] rotations;
    public static float[] xMarkers;
    public static float[] yMarkers;
    private float nullPath = 361;

    //make variables for getting waves and wave numbers
    private int wave;
	private float delay = -5f;
    private bool complete = true;

    //make variables for inside waves
	private float spawnTimer = 0f;
	private int i = 0;
    private int length;
	private int order = 0;

	void Start ()
    {

	}

	void Update ()
    {
		//get a wave number
		//IF there has passed more than 10 seconds AND the last wave is COMPLETE, get a new random WAVE
		if (Time.time - delay > 10 && complete == true) {
			wave = Random.Range(1, 4);
			complete = false;
			delay = Time.time;
            i = 0;
            order = 0;
		}
		//trigger the waves
		//IF the wave is not complete yet, trigger the wave
		if (complete == false) {
			if (wave == 1)
			{
				wave1();
			}
			else if (wave == 2)
			{
				wave2();
			}
            else if (wave == 3)
            {
                wave3();
            }
		}
	}

	private void wave1 ()
    {
        length = 9;
		if (i < length && Time.time - spawnTimer > 0.3) {
            if (order == 0 || order == 1 || order == 2)
            {
    			//fill the arrays with path keypoints
    			enemySpeed = 7;
    			angles = new float[] {35, 125, 35, 125, 35, 125, 90};
    			rotations = new string[] {"right", "left", "right", "left", "right", "left", "right"};
    			xMarkers = new float[] {nullPath, nullPath, nullPath, nullPath, nullPath, nullPath, nullPath};
    			yMarkers = new float[] {2, -2, 2, -2, 2, -2, nullPath};
    			rotationSpeeds = new float[] {180, 180, 180, 180, 180, 180, 180};

                position = new Vector3(General.rightBorder, 0, 1);
    			Instantiate (RegularEnemy, position, Quaternion.Euler(0, 0, 90));
    			spawnTimer = Time.time;
    			i++;
            }
            else if (order == 3 || order == 4 || order == 5)
            {
                //fill the arrays with path keypoints
                enemySpeed = 7;
                angles = new float[] {35, 125, 35, 125, 35, 125, 90};
                rotations = new string[] {"right", "left", "right", "left", "right", "left", "right"};
                xMarkers = new float[] {nullPath, nullPath, nullPath, nullPath, nullPath, nullPath, nullPath};
                yMarkers = new float[] {3, -3, 3, -3, 3, -3, nullPath};
                rotationSpeeds = new float[] {180, 180, 180, 180, 180, 180, 180};
                
                position = new Vector3(General.rightBorder, 0, 1);
                Instantiate (RegularEnemy, position, Quaternion.Euler(0, 0, 90));
                spawnTimer = Time.time;
                i++;
            }
            else if (order == 6 || order == 7 || order == 8)
            {
                //fill the arrays with path keypoints
                enemySpeed = 7;
                angles = new float[] {35, 125, 35, 125, 35, 125, 90};
                rotations = new string[] {"right", "left", "right", "left", "right", "left", "right"};
                xMarkers = new float[] {nullPath, nullPath, nullPath, nullPath, nullPath, nullPath, nullPath};
                yMarkers = new float[] {4, -4, 4, -4, 4, -4, nullPath};
                rotationSpeeds = new float[] {180, 180, 180, 180, 180, 180, 180};
                
                position = new Vector3(General.rightBorder, 0, 1);
                Instantiate (RegularEnemy, position, Quaternion.Euler(0, 0, 90));
                spawnTimer = Time.time;
                i++;
            }
            order++;
            complete = false;
		}
		else if (i == length) 
        {
			complete = true;
		}
	}

	private void wave2 ()
    {
        length = 10;
		if (i < length && Time.time - spawnTimer > 0.3) {
			if (order == 0 || order == 2 || order == 4 || order == 6 || order == 8)
            {
				//fill the arrays with path keypoints
				enemySpeed = 7;
				angles = new float[] {55, 110};
				rotations = new string[] {"right", "left"};
				xMarkers = new float[] {nullPath, -20};
				yMarkers = new float[] {2, nullPath};
				rotationSpeeds = new float[] {180, 180};

                position = new Vector3(General.rightBorder, -7, 1);
				Instantiate (RegularEnemy, position, Quaternion.Euler(0, 0, 90));
				spawnTimer = Time.time;
				i++;
			}
			else if (order == 1 || order == 3 || order == 5 || order == 7 || order == 9) {
				//fill the arrays with path keypoints
				enemySpeed = 7;
				angles = new float[] {145, 70};
				rotations = new string[] {"left", "right"};
				xMarkers = new float[] {nullPath, -20};
				yMarkers = new float[] {-2, nullPath};
				rotationSpeeds = new float[] {180, 180};
				
                position = new Vector3(General.rightBorder, 7, 1);
				Instantiate (RegularEnemy, position, Quaternion.Euler(0, 0, 90));
				spawnTimer = Time.time;
				i++;
			}
            order++;
			complete = false;
		}
        else if (i == length) 
        {
            complete = true;
        }
	}

    private void wave3()
    {
        length = 12;
        if (i < length && Time.time - spawnTimer > 0.3)
        {
            if (order == 0 || order == 1 || order == 2 || order == 3)
            {
                //fill the arrays with path keypoints
                enemySpeed = 7;
                angles = new float[] {110, nullPath};
                rotations = new string[] {"left", "right"};
                xMarkers = new float[] {nullPath, General.leftBorder};
                yMarkers = new float[] {-4, nullPath};
                rotationSpeeds = new float[] {90, 90};
                
                position = new Vector3(General.rightBorder, 3, 1);
                Instantiate (RegularEnemy, position, Quaternion.Euler(0, 0, 45));
                spawnTimer = Time.time;
                i++;
            }
            else if (order == 4 || order == 5 || order == 6 || order == 7)
            {
                //fill the arrays with path keypoints
                enemySpeed = 7;
                angles = new float[] {70, nullPath};
                rotations = new string[] {"right", "left"};
                xMarkers = new float[] {nullPath, General.leftBorder};
                yMarkers = new float[] {4, nullPath};
                rotationSpeeds = new float[] {90, 90};
                
                position = new Vector3(General.rightBorder, -3, 1);
                Instantiate (RegularEnemy, position, Quaternion.Euler(0, 0, 135));
                spawnTimer = Time.time;
                i++;
            }
            else if (order == 8 || order == 10)
            {
                //fill the arrays with path keypoints
                enemySpeed = 7;
                angles = new float[] {180, 105};
                rotations = new string[] {"left", "left"};
                xMarkers = new float[] {nullPath, nullPath};
                yMarkers = new float[] {2, 1};
                rotationSpeeds = new float[] {90, 90};
                
                position = new Vector3(4, General.topBorder, 1);
                Instantiate (RegularEnemy, position, Quaternion.Euler(0, 0, 225));
                spawnTimer = Time.time;
                i++;
            }
            else if (order == 9 || order == 11)
            {
                //fill the arrays with path keypoints
                enemySpeed = 7;
                angles = new float[] {0, 75};
                rotations = new string[] {"right", "right"};
                xMarkers = new float[] {nullPath, nullPath};
                yMarkers = new float[] {-2, -1};
                rotationSpeeds = new float[] {90, 90};
                
                position = new Vector3(4, General.bottomBorder, 1);
                Instantiate (RegularEnemy, position, Quaternion.Euler(0, 0, 315));
                spawnTimer = Time.time;
                i++;
            }
            order++;
            complete = false;
        }
        else if (i == length)
        {
            complete = true;
        }
    }
}
