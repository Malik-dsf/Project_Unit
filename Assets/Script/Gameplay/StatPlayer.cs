using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatPlayer : MonoBehaviour
{



    public int currentHealth = 100;
    public playerController playercontroller;


    [SerializeField]
    private GameObject deadPanel;

    // Start is called before the first frame update
    void Start()
    {
        deadPanel.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            dead();
        }


    }




    void dead()
    {
        deadPanel.SetActive(true);
        
    }
}
