using UnityEngine;
using System.Collections;

public class HomingEnemySearch : MonoBehaviour {
    private Transform myTransform;

    private float angle;
    public float rotationSpeed;
    public float baseRotationspeed;
    public Vector3 rotation;

    public Vector3 playerPosition;

	// Use this for initialization
	void Start () {
        myTransform = transform;

        rotationSpeed = 360;
	}
	
	// Update is called once per frame
	void Update()
    {

        playerPosition = Player.PlayerPositionShield;

        //IF the enemy's y axis is LOWER THAN the player's y axis + .01 AND HIGHER THAN the player's y axis - .01
        if (myTransform.position.y < playerPosition.y + 0.01 && myTransform.position.y > playerPosition.y - 0.01)
        {
            angle = 90;
            Debug.Log("Ping");
        }
        else if (playerPosition.y > myTransform.position.y && angle != 90)
        {
            rotation = Vector3.back;
            angle = 45;
        }
        else if (playerPosition.y < myTransform.position.y && angle != 90)
        {
            rotation = Vector3.forward;
            angle = 135;
        }
        else if (playerPosition.y > myTransform.position.y && angle == 90)
        {
            rotation = Vector3.back;
        } 
        else if (playerPosition.y < myTransform.position.y && angle == 90)
        {
            rotation = Vector3.forward;
        }

        if (myTransform.rotation.eulerAngles.z < angle + 45f && myTransform.rotation.eulerAngles.z > angle - 45f)
        {
            myTransform.rotation = Quaternion.Euler(0, 0, angle);
        }
        else if (!(myTransform.rotation.eulerAngles.z < angle + 5f && myTransform.rotation.eulerAngles.z > angle - 5f))
        {
            myTransform.Rotate(rotation * rotationSpeed * Time.deltaTime);
        } 
	}
}
