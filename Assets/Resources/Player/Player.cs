using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	private Transform myTransform;
	public float playerSpeed = 5;

	// Use this for initialization
	void Start () {
			
		myTransform = transform; 
		//Spawn point		 x  y  z
		//position to be at -8,-2,-1
		
		myTransform.position = new Vector3 (-8, -2, -1);

	}
	
	// Update is called once per frame
	void Update () {
	
			
		//Move the player left and right
		
		myTransform.Translate (Vector3.right * playerSpeed * Input.GetAxis ("Horizontal") * Time.deltaTime);
		myTransform.Translate (Vector3.up * playerSpeed * Input.GetAxis ("Vertical") * Time.deltaTime);
	}
}
