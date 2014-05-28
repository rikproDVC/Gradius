using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {

	public GameObject Meteorite;

	public float Delay= 5F;
	public float YMin = -4.9F;
	public float YMax = 4.9F;
	

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
			Meteorite.transform.position = new Vector3 (23, Random.Range(YMin,YMax) ,5);
			Instantiate (Meteorite);
			}
		
}