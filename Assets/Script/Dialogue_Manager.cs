using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue_Manager : MonoBehaviour
{

    public static Dialogue_Manager Instance;

    public Text nameText;
    public Text dialogueText;

    private Queue<string> sentences;

    private void Awake()
    {
        if(Instance != null)
        {
            Debug.LogWarning("il n'y a plus d'une instance dans DIalogManager");
            return;
        }


        Instance = this;


    }

    public void StartDialogue(Dialogue dialogue)
    {
        nameText.text = dialogue.name;

        sentences.Clear(); 

        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        Debug.Log("ouioui");
        DisplayNextSentence();

    }

    void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;

    }



    void EndDialogue()
    {
        Debug.Log("Finish");
    }


}
