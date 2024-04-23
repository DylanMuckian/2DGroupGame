using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    /// <summary>
    /// setting to make dialog happen once or repeat
    /// </summary>
    public bool oneShot = false;

    AetherRunScript AS;
    PlayerController playerController;

    public GameObject dialoguePanel;
    public Text dialogueText;
    public string[] dialogue;
    public int index;

    public GameObject contButton;
    public float wordSpeed;
    public bool playerIsClose;
    
    void Update()  
    {
        if (Input.GetKeyDown(KeyCode.E) && playerIsClose)
        {
            if (dialoguePanel.activeInHierarchy)
            {
                zeroText();
            }
            else
            {
                dialoguePanel.SetActive(true);
                //StartCoroutine(Typing());
            }
        }
        
        //note: this is comparing a string to an int - this will never be true??
        // if(dialogueText.text == dialogue[index])
        // {
        //     contButton.SetActive(true);
        // }
      
    }

    public void zeroText()
    {
        dialogueText.text = "";
        index = 0;
        dialoguePanel.SetActive(false);
    }

    IEnumerator Typing()
    {
        foreach(char letter in dialogue[index].ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(wordSpeed);
        }
    }

    public void NextLine()
    {
        //note: changed the conditions to length minus one
        if(index < dialogue.Length-1)
        {
            index++;
            dialogueText.text = "";
            StartCoroutine(Typing());
        }
        else if(index == dialogue.Length-1)
        {
            zeroText();
            dialoguePanel.SetActive(false);
            contButton.SetActive(false);
            if (oneShot)
            {
                //Destroy or remove 
                print("Destroy dialog if oneshot");
                Destroy(this.gameObject);

            }
        }
        
        
        // else
        // {
        //     zeroText();
        //     dialoguePanel.SetActive(false);
        //     contButton.SetActive(false);
        // }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
      if (other.CompareTag("Player"))
        {
            playerIsClose = true;
            dialoguePanel.SetActive(true);
            StartCoroutine(Typing());
            AS.canMove = false;
            
        }
    }
    public void OnTriggerExit2D(Collider2D other) 
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = false;
            zeroText();
            AS.canMove = true;
           
        }
    }

    
    
    

}