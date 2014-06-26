using UnityEngine;
using System.Collections;

public class HomingEnemySearch : MonoBehaviour {
    private Transform myTransform;

    private float angle;

    public Vector3 playerPosition;

    public float rotateTimer;

	// Use this for initialization
	void Start () {
        myTransform = transform;
	}
	
	// Update is called once per frame
	void Update()
    {
        playerPosition = Player.PlayerPositionShield;

        if (playerPosition.x < myTransform.position.x)
        {
            //IF the enemy's y axis is LOWER THAN the player's y axis + .01 AND HIGHER THAN the player's y axis - .01
            if (myTransform.position.y < playerPosition.y + 0.1 && myTransform.position.y > playerPosition.y - 0.1)
            {
                    angle = 90;
                    myTransform.rotation = Quaternion.Euler(0, 0, angle);
            } else if (playerPosition.y > myTransform.position.y)
            {
                if (Time.time - rotateTimer > 0.2)
                {
                    angle = 45;
                    myTransform.rotation = Quaternion.Euler(0, 0, angle);
                    rotateTimer = Time.time;
                }
            } else if (playerPosition.y < myTransform.position.y)
            {
                if (Time.time - rotateTimer > 0.2)
                {
                    angle = 135;
                    myTransform.rotation = Quaternion.Euler(0, 0, angle);
                    rotateTimer = Time.time;
                }
            }
        } else
        {
            angle = 90;
            myTransform.rotation = Quaternion.Euler(0, 0, angle);
        }
	}
}
