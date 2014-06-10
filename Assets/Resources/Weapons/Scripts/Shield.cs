using UnityEngine;
using System.Collections;

public class Shield : MonoBehaviour {

    private Transform myTransform;
    private Vector3 Position;

	// Use this for initialization
	void Start ()
    {
        myTransform = transform;
	}
	
	// Update is called once per frame
	void Update ()
    {
        //Shield stays on the player even when moving
        Position = Player.PlayerPositionShield;
        myTransform.position = Position;

        if (Player.Shield == 0)
        {
            Player.ShieldActive = false;
            Destroy(this.gameObject);
        }
	}
}
