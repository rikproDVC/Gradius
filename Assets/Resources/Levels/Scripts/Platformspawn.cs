using UnityEngine;
using System.Collections;

public class Platformspawn: MonoBehaviour
{
	private Vector3 position;
	public GameObject Prefab;
	public GameObject Prefab2;
	private bool spawned;
	private bool spawned2;
	
	void Start()
	{
		spawned = false;
		spawned2 = false;
		
	}
	
	void Update()
	{
		
		if (Player.PlayerScore == 1000) {
			if (spawned == false) {
				Invoke ("spawn", 0f);
				spawned = true;
			}
		}
		if (Player.PlayerScore == 2000) {
			if (spawned2 == false) {
				Invoke ("spawn2", 0f);
				spawned2 = true;
			}
		}
		
		
	}
	
	void spawn()
	{
		position =new Vector3 (23, 0.3f ,1);
		Instantiate (Prefab,position,Quaternion.identity);
	}
	void spawn2()
	{
		position =new Vector3 (23, 0.3f ,1);
		Instantiate (Prefab2,position,Quaternion.identity);
	}
}