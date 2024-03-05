using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{

    public Dialogue dialogues;
    public DialogueManager manager;
    public GameObject text_Active;

    public bool isInRange;
    public bool isActive;


    // Update is called once per frame
    void Update()
    {
        if(isInRange && Input.GetKeyDown(KeyCode.E))
        {
            TriggerDialogue();
        }

        if (isInRange == true && isActive == false)
        {
            text_Active.SetActive(true);
        }
        else
        {
            text_Active.SetActive(false);
        }

        if (isActive)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                manager.DisplayNextSentences();
                Debug.Log("KeyDownnext");

            }
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.gameObject.tag == "Player")
        {
            isInRange = true;
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.gameObject.tag == "Player")
        {
            isInRange = false;
            DialogueManager.instance.EndDialogue();
            isActive = false;
        }
    }


    void TriggerDialogue()
    {
        isActive = true;
        DialogueManager.instance.StartDialogue(dialogues);
    }


}
