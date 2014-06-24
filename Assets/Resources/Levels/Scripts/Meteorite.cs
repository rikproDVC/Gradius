using UnityEngine;
using System.Collections;

public class Meteorite : MonoBehaviour {

	private Transform MyTransform;
    private int Speed = 10;

	// Use this for initialization
	void Start ()
	{
		MyTransform = transform;	
	}
	
	// Update is called once per frame
	void Update ()
	{
        MyTransform.Translate (Vector3.left * Speed * Time.deltaTime);

        Vector3 viewPos = Camera.main.WorldToViewportPoint(MyTransform.position);
        if (viewPos.x < -0.5F)
        {
            Destroy(this.gameObject);
        }
        if (MyTransform.position.y  < General.bottomBorder -2 || MyTransform.position.y  > General.topBorder +2 )
        {
            Destroy(this.gameObject);
        }
	}
}