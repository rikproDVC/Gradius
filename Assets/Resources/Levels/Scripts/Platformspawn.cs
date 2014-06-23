using UnityEngine;
using System.Collections;

public class Platformspawn: MonoBehaviour
{
	public GameObject Prefab;
	public GameObject Prefab2;

	private Vector3 position;
	private bool spawned1;
	private bool spawned2;

	// Use this for initialization
	void Start()
	{
        spawned1 = false;
        spawned2 = false;
	}
	
	void Update()
	{
		if (Player.PlayerScore >= 1000)
        {
            if (spawned1 == false)
			{
				Invoke ("spawn1", 0f);
                spawned1 = true;
			}
		}
		if (Player.PlayerScore >= 2000)
        {
			if (spawned2 == false)
			{
				Invoke ("spawn2", 0f);
                spawned2 = true;
			}
		}
	}
	
	void spawn1()
	{
		position = new Vector3 (General.rightBorder, 0 ,1);
		Instantiate (Prefab,position,Quaternion.identity);
	}
	void spawn2()
	{
        position = new Vector3 (General.rightBorder, 0 ,1);
		Instantiate (Prefab2,position,Quaternion.identity);
	}
}