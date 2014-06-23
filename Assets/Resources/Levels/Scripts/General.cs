using UnityEngine;
using System.Collections;

public class General : MonoBehaviour {

	public GameObject PlayerFab;

    public static float leftBorder;
    public static float rightBorder;
    public static float topBorder;
    public static float bottomBorder;
    public float dist;

    private Vector3 position;
    private int Speed = 5;

	// Use this for initialization
	void Start()
    {
        position = new Vector3(0, 0, 1);
        if (Application.loadedLevelName == "GradiusMenu")
        {

        } else
        {
            Instantiate(PlayerFab, position, Quaternion.identity);
        }   
	}
	
	// Update is called once per frame
	void Update()
	{

        dist = (transform.position - Camera.main.transform.position).z;
        
        leftBorder = Camera.main.ViewportToWorldPoint (new Vector3 (0, 0, dist)).x;
        rightBorder = Camera.main.ViewportToWorldPoint (new Vector3 (1, 0, dist)).x;
        topBorder = Camera.main.ViewportToWorldPoint(new Vector3 (0, 1, dist)).y;
        bottomBorder = Camera.main.ViewportToWorldPoint (new Vector3 (0, 0, dist)).y;        
	}
}
