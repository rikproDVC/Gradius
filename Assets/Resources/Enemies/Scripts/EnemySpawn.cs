using UnityEngine;
using System.Collections;

public class EnemySpawn : MonoBehaviour {
	private float delay = -5f;
	private float spawnTimer = 0f;
	public GameObject RegularEnemy;
	private Vector3 position;
	private int i = 0;
	private bool complete = true;
	private int wave;

	private int order = 0;

	//make arrays for the path keypoints
	public static float enemySpeed;
	public static float[] angles;
	public static float[] rotationSpeeds;
	public static string[] rotations;
	public static float[] xMarkers;
	public static float[] yMarkers;

	private float nullPath = 361;

	void Start ()
    {

	}

	void Update ()
    {
		//get a wave number
		//IF there has passed more than 10 seconds AND the last wave is COMPLETE, get a new random WAVE
		if (Time.time - delay > 10 && complete == true) {
			wave = Random.Range(1, 3);
			complete = false;
			delay = Time.time;
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
		if (i < 10 && Time.time - spawnTimer > 0.3) {
            if (order == 0 || order == 1 || order == 2 || order == 3 || order == 4)
            {
    			//fill the arrays with path keypoints
    			enemySpeed = 7;
    			angles = new float[] {35, 125, 35, 125, 35, 125, 90};
    			rotations = new string[] {"right", "left", "right", "left", "right", "left", "right"};
    			xMarkers = new float[] {nullPath, nullPath, nullPath, nullPath, nullPath, nullPath, 12};
    			yMarkers = new float[] {2, -2, 2, -2, 2, -2, nullPath};
    			rotationSpeeds = new float[] {180, 180, 180, 180, 180, 180, 180};

                position = new Vector3(General.rightBorder, 0, 1);
    			Instantiate (RegularEnemy, position, Quaternion.Euler(0, 0, 90));
    			spawnTimer = Time.time;
    			i++;
            }
            else if (order == 6 || order == 7 || order == 8 || order == 9 || order == 10 )
            {
                //fill the arrays with path keypoints
                enemySpeed = 7;
                angles = new float[] {125, 35, 125, 35, 125, 35, 90};
                rotations = new string[] {"left", "right", "left", "right", "left", "right", "left"};
                xMarkers = new float[] {nullPath, nullPath, nullPath, nullPath, nullPath, nullPath, 12};
                yMarkers = new float[] {-2, 2, -2, 2, -2, 2, nullPath};
                rotationSpeeds = new float[] {180, 180, 180, 180, 180, 180, 180};
                
                position = new Vector3(General.rightBorder, 0, 1);
                Instantiate (RegularEnemy, position, Quaternion.Euler(0, 0, 90));
                spawnTimer = Time.time;
                i++;
            }
            order++;
            complete = false;
		}
		else if (i >= 10) {
			i = 0;
            order = 0;
			complete = true;
		}
	}

	private void wave2 ()
    {
		if (i < 10 && Time.time - spawnTimer > 0.3) {
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
		else if (i >= 10) {
			i = 0;
			complete = true;
			order = 0;
		}
	}

    private void wave3()
    {
        if (i < 9 && Time.time - spawnTimer > 0.3)
        {
            //fill the arrays with path keypoints
            enemySpeed = 7;
            angles = new float[] {145, 70};
            rotations = new string[] {"left", "right"};
            xMarkers = new float[] {nullPath, -20};
            yMarkers = new float[] {-2, nullPath};
            rotationSpeeds = new float[] {180, 180};
        }
    }
}
