using UnityEngine;
using System.Collections;

public class HomingEnemySearch : MonoBehaviour {
    private Transform myTransform;

    private float angle;
    public float rotationSpeed;
    public Vector3 rotation;

    public Vector3 playerPosition;

	// Use this for initialization
	void Start () {
        myTransform = transform;

        rotationSpeed = 135 + (40 * EnemySpawn.stage - 20);
	}
	
	// Update is called once per frame
	void Update()
    {
        playerPosition = Player.PlayerPositionShield;

        if (!(myTransform.position.y < playerPosition.y + 2 || myTransform.position.y > playerPosition.y - 2))
        {
            angle = 90;
        }
        else if (playerPosition.y > myTransform.position.y)
        {
            rotation = Vector3.back;
            angle = 45;
        }
        else if (playerPosition.y < myTransform.position.y)
        {
            rotation = Vector3.forward;
            angle = 135;
        }

        if (!(myTransform.rotation.eulerAngles.z < angle + 2f && myTransform.rotation.eulerAngles.z > angle - 2f))
        {
            myTransform.Rotate(rotation * rotationSpeed * Time.deltaTime);
        }
	}
}
