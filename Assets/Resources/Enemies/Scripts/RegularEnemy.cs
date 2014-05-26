using UnityEngine;
using System.Collections;

public class RegularEnemy : MonoBehaviour {
	private Transform myTransform;
	public static float enemySpeed = 10;

	// Use this for initialization
	void Start () {
		myTransform = transform;

		myTransform.position = new Vector3(0, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {

	}
}
