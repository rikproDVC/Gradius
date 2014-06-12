using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public static int PowerLevel = 0;
    public static int PlayerScore = 0;
    public static int PlayerLives = 3;
    public static int Shield = 1;
   
	public static Vector3 PlayerPosition;

	private float Speed = 8;
	private Transform myTransform;

	// Use this for initialization
	void Start()
	{
		myTransform = transform;
		myTransform.localScale = new Vector3(2, 2, 0);
	}
	
	// Update is called once per frame
	void Update()
	{
		//Power Up
		if(PowerLevel == 1)
		{
			Speed = 10;
		}
		if(PowerLevel == 2)
		{
			Speed = 12;
		}
		if(PowerLevel == 3)
		{
			Speed = 14;
		}
		if(PowerLevel == 4)
		{
			Speed = 16;
		}

		//Move the player left and right
		myTransform.Translate (Vector3.right * Speed * Input.GetAxis ("Horizontal") * Time.deltaTime);
		myTransform.Translate (Vector3.up * Speed * Input.GetAxis ("Vertical") * Time.deltaTime);

		var dist = (transform.position - Camera.main.transform.position).z;
		
		var leftBorder = Camera.main.ViewportToWorldPoint(
			new Vector3(0, 0, dist)
			).x;
		
		var rightBorder = Camera.main.ViewportToWorldPoint(
			new Vector3(1, 0, dist)
			).x;
		
		var topBorder = Camera.main.ViewportToWorldPoint(
			new Vector3(0, 0, dist)
			).y;
		
		var bottomBorder = Camera.main.ViewportToWorldPoint(
			new Vector3(0, 1, dist)
			).y;
		
		transform.position = new Vector3(
			Mathf.Clamp(myTransform.position.x, leftBorder, rightBorder),
			Mathf.Clamp(myTransform.position.y, topBorder, bottomBorder),
			myTransform.position.z
			);

		//PlayerPosition used for Laser
		PlayerPosition = new Vector3(myTransform.position.x + 5.4f, myTransform.position.y, myTransform.position.z);
	}

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Platform")
        {
            Player.PlayerScore -= 200;
        }
    }


}
