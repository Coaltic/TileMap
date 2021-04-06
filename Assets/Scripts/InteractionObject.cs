using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionObject : MonoBehaviour
{
    [Header("Used for objects that give simple info about themselves")]
    public bool info;
    [TextArea]
    public string[] messages;
    public Text infoText;

    [Header("This object can be picked up")]
    [Space]
    public bool pickup;
    public bool gemPickup;

    [Header("Used for NPC dialogue, with multiple screens")]
    [Space]
    public bool talks;
    [TextArea]
    public string[] sentences;
    [TextArea]
    public string[] secretSentences;

    public int i;

    private bool interacted = false;

    void Start()
    {
        infoText = GameObject.Find("InfoText").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
       i = Random.Range(0, 10);
    }

    public void Info()
    {

        StartCoroutine(ShowInfo(messages[i], 3.0f));
    }

    public void PickUp()
    {
        Debug.Log("You picked up " + this.gameObject.name);
        this.gameObject.SetActive(false);
    }

    public void Talks()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(sentences);
        //Debug.Log(gameObject.name + " has nothing to say to you");
    }

    public void SecretTalks()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(secretSentences);
        //Debug.Log(gameObject.name + " has nothing to say to you");
    }

    IEnumerator ShowInfo(string message, float delay)
    {
        if (interacted == false)
        {
            interacted = true;
            infoText.text = message;
            yield return new WaitForSeconds(delay);
            infoText.text = null;
            interacted = false;
        }
    }
}
