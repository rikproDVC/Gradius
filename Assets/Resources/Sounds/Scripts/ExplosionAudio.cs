using UnityEngine;
using System.Collections;

public class ExplosionAudio : MonoBehaviour {

    private float Timer;
    
    // Use this for initialization
    void Start()
    {
        Timer = Time.time;
    }
    
    // Update is called once per frame
    void Update()
    {
        //destroy after 1 sec.
        if (Time.time - Timer > 1f)
        {
            Destroy(this.gameObject); 
        }
    }
}
