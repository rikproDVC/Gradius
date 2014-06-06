using UnityEngine;
using System.Collections;

public class General : MonoBehaviour {

	public GameObject PlayerFab;
	public GameObject RegularEnemyFab;

	public Vector3 position;

	// Use this for initialization
	void Start()
	{
		position = new Vector3(0, 0, 1);
		Instantiate(PlayerFab, position, Quaternion.identity);
		position = new Vector3(15, 0, 1);
		Instantiate(RegularEnemyFab, position, Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update()
	{

	}
}
