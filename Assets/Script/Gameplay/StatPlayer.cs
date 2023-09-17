using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatPlayer : MonoBehaviour
{



    public int currentHealth = 100;
    public GameObject player;
    public playerController playercontroller;


    [SerializeField]
    private GameObject deadPanel;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = 100;
        notdead();


    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            dead();
        }
        else
        {
            notdead();
        }


    }

    void notdead()
    {
        deadPanel.SetActive(false);
        player.GetComponent<playerController>().enabled = true;


    }


    void dead()
    {
        deadPanel.SetActive(true);
        player.GetComponent<playerController>().enabled = false;
        Cursor.lockState = CursorLockMode.None;


    }
}
