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

        if (!renderer.IsVisibleFrom(Camera.main))
		{
			DestroyObject(this.gameObject);
		}
	}
}