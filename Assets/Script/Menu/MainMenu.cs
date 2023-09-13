using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public GameObject scenesToLoad;



    public void NewGame()
    {
        SceneManager.LoadScene(2);

    }

    public void QuitGameButton()
    {
        Application.Quit();
    }
}
