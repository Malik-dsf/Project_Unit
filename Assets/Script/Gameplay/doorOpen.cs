using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorOpen : MonoBehaviour
{
    public GameObject doorLink;
    [SerializeField]
    private bool doorIsOpen = false;



    private void Update()
    {
        
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {

        if (other.transform.gameObject.tag == "Player")
        {
            if (!doorIsOpen)
            {
                doorLink.SetActive(false);
            }
            else
            {
                Debug.Log("<b><color=blue>vous êtes bloquer par la porte </color></b>" + this.gameObject.name);

            }

        }
        else
        {
            doorLink.SetActive(true);
        }




    }
}
