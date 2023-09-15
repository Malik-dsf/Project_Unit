using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class credit : MonoBehaviour
{
    
    void Update()           
    {
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            LoadSceneMenu();
        }
    }

    public void LoadSceneMenu()
    {
        SceneManager.LoadScene(0);
    }

}
