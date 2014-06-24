using System;
using UnityEngine;

public class pause : MonoBehaviour
{
	public static bool paused = false;
    public Texture2D PauseFab;

    public int centerx;
    public int centery;


  

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
           
//            renderer.enabled= false;
			return(false);
		}
		else
		{
			Time.timeScale = 0f;
            audio.mute = true;
        
//            renderer.enabled= true;
			return(true);    
		}
	}
      void OnGUI()
    {
        if (paused == true)
        {
            GUI.Label(new Rect(Screen.width/2 - 90, Screen.height/2, 200, 200), PauseFab); 
        } else
        {
        
        }
    }
}

