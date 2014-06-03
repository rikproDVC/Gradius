using UnityEngine;

/// <summary>
/// Simply moves the current game object
/// </summary>
public class MoveScript : MonoBehaviour
{
	// 1 - Designer variables
	
	/// <summary>
	/// Object speed
	/// </summary>
	public int xSpeed = 5;
	
	void Update()
	{
		if (gameObject.tag == "Meteorite" || gameObject.tag == "Powerup" || gameObject.tag =="Platform" ) {
						transform.Translate (Vector3.left * xSpeed * Time.deltaTime);
				}
		if (gameObject.tag == "Enemy") {
			transform.Translate(Vector3.down * xSpeed * Time.deltaTime);
				}
			}
	}
	
	
