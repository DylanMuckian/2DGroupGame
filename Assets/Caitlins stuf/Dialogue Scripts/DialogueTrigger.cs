using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public PuzzleGameWindow dialogueScript;
    private bool playerDetected;


    //detect trigger with player
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if we triggered the player enable playerdetected and show indicator
        if (collision.tag == "Player")
        { 
            playerDetected = true;
            dialogueScript.ToggleIndicator(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //if we lost trigger with player disable playerdetected and hide indictator 
        if (collision.tag == "Player")
        {
            playerDetected = false;
            dialogueScript.ToggleIndicator(true);
        }
    }

    //while detected  if we interact start dialogue
    private void Update()
    {
        if(!playerDetected && Input.GetKeyDown(KeyCode.E))
        {
            dialogueScript.StartDialogue();
        }
    }
}
