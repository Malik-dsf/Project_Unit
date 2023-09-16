using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class finishLevel : MonoBehaviour
{
    public bool actived;
    public int levelToLoad;



    private void OnTriggerEnter(Collider other)
    {
        if (actived == true)
        {
            if (other.transform.gameObject.tag == "Player")
            {
                SceneManager.LoadScene(levelToLoad);
                Cursor.lockState = CursorLockMode.None;
            }


        }
    }
}
