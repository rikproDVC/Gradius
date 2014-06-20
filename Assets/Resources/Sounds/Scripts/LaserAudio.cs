using UnityEngine;
using System.Collections;

public class LaserAudio : MonoBehaviour {

    private float Timer;

	// Use this for initialization
	void Start () 
    {
        Timer = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
	
        //destroy when laser is gone.
        if (LaserPU.LaserActive == false)
        {
            Destroy(this.gameObject); 
        }
	}
}
