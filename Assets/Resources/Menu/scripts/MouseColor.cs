using UnityEngine;
using System.Collections;

public class MouseColor : MonoBehaviour 
{
    public bool isQuit = false;
    public bool isSound = false;

    void OnMouseEnter()
    {
        renderer.material.color = Color.red;
    }

    void OnMouseExit()
    {
        renderer.material.color = Color.white;
    }

    void OnMouseDown()
    {
        if(isQuit)
        {
            Application.Quit();
        }
        if(isSound)
        {
            Application.LoadLevel("SoundOptions");
        }
        else
        {
           Application.LoadLevel("Stage1");
        }
    }
}
