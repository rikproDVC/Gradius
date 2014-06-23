using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public static int PowerLevel = 0;
    public static int PlayerScore = 0;
    public static int PlayerLives = 3;
    public static int Shield = 4;
    public static bool ShieldActive = false;
    public static Vector3 PlayerPositionLaser;
    public static Vector3 PlayerPositionShield;
    public GameObject ShieldFab;

	private float Speed = 8;
	private Transform myTransform;

	// Use this for initialization
	void Start()
	{
		myTransform = transform;
	}
	
	// Update is called once per frame
	void Update ()
    {
        //Power Up
        if (PowerLevel == 1) {
            Speed = 10;
        }
        if (PowerLevel == 2) {
            Speed = 12;
        }
        if (PowerLevel == 3) {
            Speed = 14;
        }
        if (PowerLevel == 4) {
            Speed = 16;
        }

        //Move the player left and right
        myTransform.Translate (Vector3.right * Speed * Input.GetAxis ("Horizontal") * Time.deltaTime);

        myTransform.Translate (Vector3.up * Speed * Input.GetAxis ("Vertical") * Time.deltaTime);	

      
        transform.position = new Vector3 (
			Mathf.Clamp (myTransform.position.x, General.leftBorder, General.rightBorder),
			Mathf.Clamp (myTransform.position.y, General.bottomBorder, General.topBorder),
			myTransform.position.z
        );

        //PlayerPosition used for Laser + shield
        PlayerPositionLaser = new Vector3 (myTransform.position.x + 5.4f, myTransform.position.y, myTransform.position.z);
        PlayerPositionShield = new Vector3 (myTransform.position.x, myTransform.position.y, myTransform.position.z - 1);

        //Shield
        if (Shield > 0 && ShieldActive == false) {
            PlayerPositionShield = new Vector3 (myTransform.position.x, myTransform.position.y, myTransform.position.z);
            Instantiate (ShieldFab, PlayerPositionShield, Quaternion.identity);
            ShieldActive = true;
        }

	}
}
