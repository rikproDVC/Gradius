using UnityEngine;
using System.Collections;

public class BulletAudio : MonoBehaviour {

    private float Timer;


	// Use this for initialization
	void Start ()
    {
        Timer = Time.time;
	}
	
	// Update is called once per frame
	void Update()
    {
        //destroy after 3 sec.
        if (Time.time - Timer > 3f)
        {
          Destroy(this.gameObject); 
        }
	}
}
