using UnityEngine;
using System.Collections;

public class General : MonoBehaviour {

	public GameObject PlayerFab;

	public Vector3 position;

	// Use this for initialization
	void Start()
	{
		position = new Vector3(0, 0, 0);
		Instantiate(PlayerFab, position, Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update()
	{
		print("Laser Charge: " + Player.LaserCharge);
	}
}
