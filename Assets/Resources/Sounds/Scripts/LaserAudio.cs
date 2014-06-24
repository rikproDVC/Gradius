using UnityEngine;
using System.Collections;

public class LaserAudio : MonoBehaviour {

	// Use this for initialization
	void Start() 
    {

	}
	
	// Update is called once per frame
	void Update()
    {
        //destroy when laser is gone.
        if (LaserPU.LaserCharge == 0)
        {
            Destroy(this.gameObject); 
        }
	}
}
