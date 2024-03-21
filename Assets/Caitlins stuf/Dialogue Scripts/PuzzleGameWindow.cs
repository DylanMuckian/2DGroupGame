using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Runtime.CompilerServices;

public class PuzzleGameWindow : MonoBehaviour
{
    //window and fields
    public GameObject window;
    //indicator
    public GameObject indicator;
    //text component 
    public TMP_Text dialogueText;
    
    //dialogue list
    public List<string> dialogues;
    //writing speed
    public float writingSpeed;
    //index on dialogue
    private int index;
    //character index
    private int charIndex;
    //started boolean
    private Boolean started;
    //wait for next boolean
    private bool waitForNext;

    private void Awake()
    {
        ToggleIndicator(false);
        ToggleWindow(false);
    }
    private void ToggleWindow(bool show)
    {
        window.SetActive(show);
    }

    public void ToggleIndicator(bool show)
    {
        indicator.SetActive(show);
    }

    public void StartDialogue()
    {
        if (started)
            return;

        //booloean to show we have started
        started = true;

        //show window
        ToggleWindow(true);

        //hide indictor 
        ToggleIndicator(false);

        //start with first dialogue
        GetDialogue(0);
    }

    private void GetDialogue(int i)
    {
        //start index at zero
        index = i;
        //reset the character index
        charIndex = 0;
        //clear the dialogue component text
        dialogueText.text = string.Empty;
        //start writing
        StartCoroutine(Writing());
    }
    public void EndDialogue(int i)
    { 
    //hide window
    ToggleWindow(false);
    
    }

    IEnumerator Writing()
    {
        string currentDialogue = dialogues[index];
        //write the the character
        dialogueText.text += currentDialogue[charIndex];
        //increase the character index
        charIndex++;
        //make sure you have  reached the end of sentence
        if(charIndex < currentDialogue.Length)
        {
            //wait  x amount of seconds
            yield return new WaitForSeconds(writingSpeed);

            //restart the same process
            StartCoroutine(Writing());
        }
        else
        {
            waitForNext = true;
            //end this sentence and wait for the next one
        }
    }
    private void Update()
    {
        if(started)
            return;

        if(waitForNext && Input.GetKeyDown(KeyCode.E))
        {
            waitForNext = false;
            index++;
            if (index < dialogues.Count)
            {
                GetDialogue(index);
            }
            else
            { 
                //end dialogue();
            }
        }
    }
}
