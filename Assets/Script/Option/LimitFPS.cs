using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitFPS : MonoBehaviour
{
    public bool illimitedFPS = false;
    public bool Vsync = false;
    public int FPS = 60;

    // Start is called before the first frame update
    void Start()
    {
        if(Vsync == true)
        {
            illimitedFPS = false;
            Application.targetFrameRate = Screen.currentResolution.refreshRate;
        }
        if(Vsync == false)
        {
            if (illimitedFPS == true)
            {
                FPS = -1;
            }
            Application.targetFrameRate = FPS;

        }
        else
        {
            Debug.LogError("pb de FrameRate");
        }




    }

    
}
