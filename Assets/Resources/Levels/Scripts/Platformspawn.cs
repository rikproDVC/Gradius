using UnityEngine;
using System.Collections;

public class Platformspawn: MonoBehaviour
{
	public GameObject Prefab;
    public GameObject Prefab2;

    private Vector3 position = new Vector3 (23, 0.3f ,1);
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
		if (Player.PlayerScore == 1000)
        {
            if (spawned1 == false)
			{
             	Invoke ("Example", 0f);
                spawned1 = true;
			}
		}
		if (Player.PlayerScore == 9000)
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
        position = new Vector3 (23, 0.3f ,1);
       Instantiate(Prefab,position, Quaternion.identity);
    
          
	}
	void spawn2()
	{
		position = new Vector3 (23, 0.3f ,1);
		Instantiate (Prefab2,position,Quaternion.identity);
	}
}
