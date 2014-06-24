using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour {

    private float Timer = 0f;

	// Use this for initialization
	void Start ()
    {
        Timer = Time.time;
	}
	
	// Update is called once per frame
	void Update()
    {
        if (Time.time - Timer > 1f)
        {
            Destroy(this.gameObject);
        }
	}
}
