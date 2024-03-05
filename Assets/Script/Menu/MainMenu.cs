using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public GameObject PanelStart;
    public GameObject PanelOption;
    public GameObject PanelMainMenu;


    private void Start()
    {
        PanelStart.SetActive(true);
        PanelOption.SetActive(false);
        PanelMainMenu.SetActive(false);
    }

    void Update()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        if(PanelStart == true)
        {
            if (Input.GetKeyUp(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Space))
            {
                StartMenu();
            }
        }
        
    }


    private void StartMenu()
    {
        PanelStart.SetActive(false);
        PanelMainMenu.SetActive(true);
    }

    public void OpenOption()
    {
        PanelMainMenu.SetActive(false);
        PanelOption.SetActive(true);
    }

    public void CloseOption()
    {
        PanelMainMenu.SetActive(true);
        PanelOption.SetActive(false);
    }


    public void NewGame(int _scenesToLoad)
    {
        SceneManager.LoadScene(_scenesToLoad);

    }


    public void QuitGameButton()
    {
        Application.Quit();
    }
}
