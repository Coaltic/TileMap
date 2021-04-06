using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public GameObject currentInterObject = null;
    public InteractionObject currentInterObjectScript = null;

    public bool hasGem = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && currentInterObject == true)
        {

            if (currentInterObjectScript.pickup == true)
            {
                currentInterObjectScript.PickUp();
            }

            if (currentInterObjectScript.gemPickup == true)
            {
                currentInterObjectScript.PickUp();
                hasGem = true;
            }

            if (Input.GetKeyDown(KeyCode.Space) && currentInterObjectScript.info == true)
            {
                currentInterObjectScript.Info();
            }

            if (Input.GetKeyDown(KeyCode.Space) && currentInterObjectScript.talks == true && hasGem == true)
            {
                currentInterObjectScript.SecretTalks();
                hasGem = false;
            }
            else if (Input.GetKeyDown(KeyCode.Space) && currentInterObjectScript.talks == true)
            {
                currentInterObjectScript.Talks();
            }

            
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("InterObject") == true)
        {
            currentInterObject = other.gameObject;
            currentInterObjectScript = currentInterObject.GetComponent<InteractionObject>();
        }

        if (other.CompareTag("Gem") == true)
        {
            currentInterObject = other.gameObject;
            currentInterObjectScript = currentInterObject.GetComponent<InteractionObject>();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("InterObject") == true)
        {
            currentInterObject = null;
        }
    }
}
