using UnityEngine;
using System.Collections;

public class RocketAudio : MonoBehaviour {

    private float Timer;
    
    // Use this for initialization
    void Start ()
    {
        Timer = Time.time;
    }
    
    // Update is called once per frame
    void Update()
    {
        //destroy after 2 sec.
        if (Time.time - Timer > 2f)
        {
            Destroy(this.gameObject); 
        }
    }
}
