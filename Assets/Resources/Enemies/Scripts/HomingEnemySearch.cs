using UnityEngine;
using System.Collections;

public class HomingEnemySearch : MonoBehaviour {
    private Transform myTransform;

    private float angle;

    public Vector3 playerPosition;

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
                angle = 45;
                myTransform.rotation = Quaternion.Euler(0, 0, angle);
            } else if (playerPosition.y < myTransform.position.y)
            {
                angle = 135;
                myTransform.rotation = Quaternion.Euler(0, 0, angle);
            }
        } else
        {
            angle = 90;
            myTransform.rotation = Quaternion.Euler(0, 0, angle);
        }
	}
}
