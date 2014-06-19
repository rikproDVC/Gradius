using UnityEngine;
using System.Collections;

public class General : MonoBehaviour {

	public GameObject PlayerFab;
    public GameObject RegularEnemyFab;

    private Vector3 position;
    private int Speed = 5;

	// Use this for initialization
	void Start()
	{
		position = new Vector3(0, 0, 1);
		Instantiate(PlayerFab, position, Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update()
	{
		
	}
}
