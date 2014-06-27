using System;
using UnityEngine;

public class pause : MonoBehaviour
{
	public static bool paused = false;
    public Texture2D PauseFab;
    public GameObject MainMenuFab;

    private Vector3 position;
    private bool over = false;

    public float centerx = General.topBorder + General.bottomBorder / 2;
    public float centery = General.leftBorder + General.rightBorder / 2;

	void Update()
	{
		if(Input.GetKeyDown("p"))
			paused = togglePause();
		if(Input.GetKeyDown("escape"))
			paused = togglePause();
		
        if (Player.PlayerLives <= 0 && paused == false)
        {
            paused = togglePause();
        }

	}
	
	bool togglePause()
	{
		if(Time.timeScale == 0f)
		{
			Time.timeScale = 1f;
            audio.mute = false;
           
            //renderer.enabled= false;
			return(false);
		}
		else
		{
			Time.timeScale = 0f;
            audio.mute = true;
        
            //renderer.enabled= true;
			return(true);    
		}
	}

    void OnGUI()
    {
        if (paused == true && Player.PlayerLives > 0)
        {
            GUI.Label(new Rect(Screen.width/2 - 90, Screen.height/2, 200, 200), PauseFab); 
        }
        else if (paused ==  true && Player.PlayerLives <= 0)
        {
            if (over == false)
            {
                position = new Vector3(centerx/2, centery/2, -1);
                Instantiate(MainMenuFab, position, Quaternion.identity);
                over = true;
            }
        }
    }
}

