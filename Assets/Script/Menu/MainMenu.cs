using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{



    public void NewGame(int _scenesToLoad)
    {
        SceneManager.LoadScene(_scenesToLoad);

    }


    public void QuitGameButton()
    {
        Application.Quit();
    }
}
