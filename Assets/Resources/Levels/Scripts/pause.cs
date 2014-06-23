using System;
using UnityEngine;

public class pause : MonoBehaviour
{
	public static bool paused = false;
	
	void Update()
	{
		if(Input.GetKeyDown("p"))
			paused = togglePause();
		if(Input.GetKeyDown("escape"))
			paused = togglePause();
		
	}
	
	bool togglePause()
	{
		if(Time.timeScale == 0f)
		{
			Time.timeScale = 1f;
            audio.mute = false;
			return(false);
		}
		else
		{
			Time.timeScale = 0f;
            audio.mute = true;
			return(true);    
		}
	}
}

