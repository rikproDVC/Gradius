using UnityEngine;
using System.Collections;

public class Meteorite : MonoBehaviour {

	private Transform MyTransform;
    private int Speed = 5;

	// Use this for initialization
	void Start ()
	{
		MyTransform = transform;	
	}
	
	// Update is called once per frame
	void Update ()
	{
        MyTransform.Translate (Vector3.left * Speed * Time.deltaTime);

		if (MyTransform.position.x < -30)
		{
			DestroyObject(this.gameObject);
		}
	}
}