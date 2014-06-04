using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {

	public GameObject Meteorite;

	public float Delay= 5F;
	public float YMin = -4.9F;
	public float YMax = 4.9F;
	private Vector3 position;

	public IEnumerator Do() {
		yield return new WaitForSeconds(5);    
		// code to be executed after 5 secs
	}
	
	public void Awake ()
			{
				InvokeRepeating ("spawn", 0, Delay);
			}
	
	public void spawn ()
		{
			if (Meteorite.tag == "Meteorite") {
				position =new Vector3 (23, Random.Range(YMin,YMax) ,5);
				Instantiate (Meteorite,position,Quaternion.identity);
			}
			if (Meteorite.tag == "Enemy") {
				position =new Vector3 (23, Random.Range(YMin,YMax) ,1);
				Instantiate (Meteorite,position,Quaternion.Euler (0, 0, -90));
			}
			if (Meteorite.tag == "Powerup") {
				position =new Vector3 (23, Random.Range(YMin,YMax) ,1);
				Instantiate (Meteorite);
			}
			}
}