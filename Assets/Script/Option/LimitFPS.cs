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
        FPSIllimited();
    }


    public void VsyncOption()
    {
        Application.targetFrameRate = Screen.currentResolution.refreshRate;
        Debug.Log("<b><color=green>Vsync = selected </color></b>");

    }

    public void FPSfixe()
    {
        Application.targetFrameRate = FPS;
        Debug.Log("<b><color=green>FPS is fixed in </color></b>" + FPS);

    }

    public void FPSIllimited()
    {
        Application.targetFrameRate = -1;
        Debug.Log("<b><color=green>FPS is illimited </color></b>");

    }


}
