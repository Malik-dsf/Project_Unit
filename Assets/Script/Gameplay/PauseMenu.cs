using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{


    public static bool gameIsPaused = false;

    public GameObject PauseMenuUI;
    public GameObject MenuMainUI;
    public GameObject MenuOptionUI;


    private void Start()
    {
        Debug.Log("<b><color=red>init PauseMenu</color></b>");
        Resume();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if(gameIsPaused == true)
            {
                Resume();

            }
            else
            {
                Paused();
            }
        }
        
    }


    void Paused()
    {
        //activation du menu pause
        PauseMenuUI.SetActive(true);
        MenuMainUI.SetActive(true);
        gameIsPaused = true;
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None; 
        Cursor.visible = true;

    }

    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        MenuMainUI.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        gameIsPaused = false;
        Time.timeScale = 1;
        CloseMenuOption();

    }

    public void OpenMenuOption()
    {
        MenuOptionUI.SetActive(true);
        MenuMainUI.SetActive(false);

    }
    public void CloseMenuOption()
    {
        MenuOptionUI.SetActive(false);
        MenuMainUI.SetActive(true);

    }


    public void ReturnMainMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;

    }

    public void QuitGameButton()
    {
        Application.Quit();
    }


}
