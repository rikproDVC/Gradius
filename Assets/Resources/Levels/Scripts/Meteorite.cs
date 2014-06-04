using UnityEngine;
using System.Collections;

public class Meteorite : MonoBehaviour {
	private Transform MyTransform;
	// Use this for initialization
	void Start () {
		MyTransform = transform;	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (MyTransform.position.x < -30)
		{
			DestroyObject(this.gameObject);
		}
	}


}

