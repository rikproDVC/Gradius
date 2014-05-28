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
		transform.Translate(Vector3.left * xSpeed * Time.deltaTime);

	}
	
	
}