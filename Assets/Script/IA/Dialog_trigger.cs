using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialog_trigger : MonoBehaviour
{


    public Dialogue dialogue;
    public bool isInRange;
    

    // Update is called once per frame
    void Update()
    {
        if(isInRange && Input.GetKeyDown(KeyCode.E)){

            TriggerDialogue();
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.gameObject.tag == "Player")
        {
            isInRange = true; ;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.gameObject.tag == "Player")
        {
            isInRange = false; 
        }
    }


    private void TriggerDialogue()
    {

        Dialogue_Manager.Instance.StartDialogue(dialogue);

    }
}
