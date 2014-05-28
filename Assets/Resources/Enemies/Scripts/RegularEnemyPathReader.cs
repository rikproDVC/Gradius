using UnityEngine;
using System.Collections;

public class RegularEnemyPathReader : MonoBehaviour {
	private Transform myTransform;
	public static Vector3 targetLocation;
	private float timer;
	
	// Use this for initialization
	void Start () {
		myTransform = transform;
		myTransform.position = new Vector3(7, 0, 0);
		targetLocation = new Vector3(-3, 3, 0);
	}
	
	// Update is called once per frame
	void Update () {

	}
}
