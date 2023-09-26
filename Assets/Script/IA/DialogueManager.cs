using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

    public Text nameText;
    public Text dialogueText;

    public Animator animator;

    private Queue<string> sentences;


    public static DialogueManager instance;

    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("il y a trop de DialogueManager dans la scène!");
            return;
        }

        instance = this;

        sentences = new Queue<string>();

    }



    public void StartDialogue(Dialogue dialogue)
    {

        nameText.text = dialogue.name;
        sentences.Clear();
        animator.SetBool("IsOpen", true);


        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        
        

        DisplayNextSentences();
    }

    public void DisplayNextSentences(){

        Debug.Log("next");

        if (sentences.Count == 0){
            EndDialogue();
            return;
        }


        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    //affichage lettre par lettre
    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach(char lettre in sentence.ToCharArray())
        {
            dialogueText.text+= lettre;
            yield return new WaitForSeconds(0.01f);
        }
    }


    public void EndDialogue()
    {
        Debug.Log("fin de dialogue");
        animator.SetBool("IsOpen", false);


    }



}
