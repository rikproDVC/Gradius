using UnityEngine;
using System.Collections;

public class Platformspawn: MonoBehaviour
{
	private Vector3 position;
	public GameObject Prefab;
	private Player anotherScript;



	void Awake()
	{
		anotherScript = GetComponent<Player>();
	}

	void Start()
	{

	}

	void Update()
	{
		if (Player.PlayerScore > 1000) 
		{
			spawn();
		}
		if (Prefab.transform.position.x < -30) {
		DestroyObject (this.gameObject);
		}

	}

	void spawn()
	{
			position =new Vector3 (23, 0.3f ,1);
			Instantiate (Prefab,position,Quaternion.identity);
	}

}