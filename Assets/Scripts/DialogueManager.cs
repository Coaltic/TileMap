using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public GameObject dialogueUI;
    public Text dialogueText;
    public GameObject player;
    public Animator animator;

    private Queue<string> dialogueQueue;


    void Start()
    {
        dialogueQueue = new Queue<string>();
    }

    void Update()
    {
        
    }

    public void StartDialogue(string[] sentences)
    {
        dialogueQueue.Clear();
        dialogueUI.SetActive(true);

        player.GetComponent<PlayerMovement_2D>().enabled = false;
        player.GetComponent<PlayerInteraction>().enabled = false;

        animator.SetFloat("Speed", 0);
        player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

        foreach (string currentLine in sentences)
        {
            dialogueQueue.Enqueue(currentLine);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (dialogueQueue.Count == 0)
        {
            EndDialogue();
            return;
        }

        string currentLine = dialogueQueue.Dequeue();

        dialogueText.text = currentLine;
    }

    public void EndDialogue()
    {
        dialogueUI.SetActive(false);

        player.GetComponent<PlayerMovement_2D>().enabled = true;
        player.GetComponent<PlayerInteraction>().enabled = true;
    }
}
